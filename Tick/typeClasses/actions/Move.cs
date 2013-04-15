using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tick.typeClasses.actions
{
    class Move : Action
    {
        private readonly Area _destination;
        public Move(Entity e, Area des ) : base(e)
        {
            _destination = des;
        }

        public override void DoTick()
        {
            if( Owner.Location.TravelAttempt(Owner) )
            {
                Owner.Move(_destination);
                Complete = true;
            }
        }
    }
}
