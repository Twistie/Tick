using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Tick;
using Tick.typeClasses;

namespace Tick.messages
{
    public class MoveMessage : IMessage
    {
        public string type = "move";
        public string ent, fromx, fromy, tox, toy;
        public MoveMessage(Entity e, Area from, Area to)
        {
            this.ent = e.ID.ToString() ;
            this.fromx = from.X.ToString();
            this.fromy = from.Y.ToString();
            this.tox = to.X.ToString();
            this.toy = to.Y.ToString();
        }
        public string getJsonString()
        {
            string s = JsonConvert.SerializeObject(this);
            return JsonConvert.SerializeObject(this);
        }
    }
}
