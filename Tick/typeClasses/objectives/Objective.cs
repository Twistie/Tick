using System;
using Tick.typeClasses;
namespace Tick.typeClasses.objectives
{
    public abstract class Objective
    {
        public bool Complete { get; set; }
        protected Entity Owner;
        public abstract actions.Action GetAction();

        protected Objective( Entity o)
        {
            Complete = false;
            Owner = o;
        }
    }
}
