using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tick.homes
{
    interface IBase
    {
        ICube getCube( int x,int y, int z);
    }
}
