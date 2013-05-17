using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fleck;
using Newtonsoft.Json;
using Tick.messages;

namespace Tick
{
    public class FleckLogger : ILogger
    {
        public List<String> ReleventLogs(){
            return new List<String>();
        }
        List<IWebSocketConnection> allSockets = new List<IWebSocketConnection>();
        WebSocketServer server = new WebSocketServer("ws://localhost:8081");
        public FleckLogger()
        {
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
            public string[] args;
        }
    }
}
