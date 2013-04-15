using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tick.typeClasses.actions
{
    class Idle : Action
    {
        public Idle(Entity e) : base(e)
        {
        }

        public override void DoTick()
        {
            Complete = true;
        }
    }
}
