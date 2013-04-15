using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tick
{
    public interface ILogger
    {
        List<String> ReleventLogs();
        void Log(string s);
    }
}
