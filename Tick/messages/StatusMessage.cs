using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Tick.typeClasses;

namespace Tick.messages
{
    class StatusMessage : IMessage
    {
        public string item;
        public string type = "status";
        public StatusMessage(Character c)
        {
            item = JsonConvert.SerializeObject(c);
            
        }
        public string getJsonString()
        {
            string json = JsonConvert.SerializeObject(this);
            
            return JsonConvert.SerializeObject(this);
        }
    }
}
