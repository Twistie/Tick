using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using Action = Tick.typeClasses.actions.Action;
using Tick.typeClasses;
namespace Tick.typeClasses.objectives
{
    class Idle : Objective
    {
        public Idle(Entity o) : base(o)
        {
        }

        public override Action GetAction()
        {

            Complete = true;
            return new actions.Idle( Owner );
        }
      
    }
}
