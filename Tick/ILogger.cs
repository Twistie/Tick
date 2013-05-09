using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tick.messages;

namespace Tick
{
    public interface ILogger
    {
        List<String> ReleventLogs();
        void Log(string s);
        void Log(Object o, string s);
        void Log(IMessage m);
    }
}
