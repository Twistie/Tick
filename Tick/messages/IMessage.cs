using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tick.messages
{
    public interface IMessage
    {
        string getJsonString();
    }
}
