using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fleck;
using Newtonsoft.Json;
using Tick.messages;
using Tick.typeClasses;
using Tick.typeClasses.objectives;
namespace Tick
{
    public class FleckLogger : ILogger
    {
        public List<String> ReleventLogs(){
            return new List<String>();
        }
        List<IWebSocketConnection> allSockets = new List<IWebSocketConnection>();
        WebSocketServer server = new WebSocketServer("ws://localhost:8081");
        public LinkedList<Entity> _entList;
        public NormalWorld world;
        public void setWorld(NormalWorld w)
        {
            world = w;
        }
        public FleckLogger(LinkedList<Entity> entList)
        {
            _entList = entList;
            server.Start(socket =>
            {
                socket.OnOpen = () =>
                {
                    allSockets.Add(socket);
                };

                socket.OnClose = () => allSockets.Remove(socket);
                socket.OnMessage = message =>
                {
                    foreach (var s in allSockets.ToList())
                        s.Send(message);

                    try
                    {
                        incomingMessage i = JsonConvert.DeserializeObject<incomingMessage>(message, new JsonSerializerSettings());
                        i.process(socket, _entList, world);
                    }
                    catch (Exception e)
                    {
                        Log(e.ToString());
                    }
                };
            });
            
        }
        public void Log(string s)
        {
            Encoding.UTF8.GetBytes( s );
            foreach( IWebSocketConnection w in allSockets ) {
                w.Send(s);
            }

        }
        public void Log(Object o, string s)
        {
            Encoding.UTF8.GetBytes(s);
            foreach (IWebSocketConnection w in allSockets)
            {
                w.Send(s);
            }
        }
        public void Log( IMessage m ) {
            string s = m.getJsonString();
            Log(m.getJsonString());
        }

        public class incomingMessage {
            public string type;
            public Dictionary<String,String> args;
            public void process( IWebSocketConnection socket, LinkedList<Entity> entList,  NormalWorld world )
            {
                switch (type)
                {
                    case "entityRequest":
                        foreach( Entity e in entList ) {
                            if( e.ID == int.Parse(args["Id"])) 
                            {
                                StatusMessage toSend = new StatusMessage(e._char);
                                socket.Send(toSend.getJsonString());
                            }
                        }
                        return;
                    case "moveRoute":
                        Entity toMove = null;
                        foreach (Entity e in entList)
                        {
                            if (e.ID == int.Parse(args["Id"]))
                            {
                                toMove = e;
                            }
                        }
                        String[] coordsList = args["moveList"].Split(',');
                        Area[] route = new Area[coordsList.Length];
                        int i = 0;
                        foreach (String s in coordsList)
                        {
                            String[] coordsPair = s.Split(':');
                            route[i] = world.GetArea(int.Parse(coordsPair[0]), int.Parse(coordsPair[1]));
                            i++;
                        }
                        MoveLoop moveLoop = new MoveLoop(toMove, route, world);
                        toMove.CurObjective = moveLoop;
                        return;
                }
            }
        }
    }
}
