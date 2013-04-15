using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;
using Tick.typeClasses;

namespace Tick.typeClasses
{
    public interface IWorld
    {
        void DoTick();
        Area GetArea(int x, int y);
        
    }
}
