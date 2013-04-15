using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tick.typeClasses;


namespace Tick.typeClasses.objectives
{
    class Move : Objective
    {
        protected int XDif, YDif;
        protected readonly Area Destination;
        protected readonly IWorld WorldMap; 
        public Move(Entity o, Area d, IWorld map) : base(o)
        {
            WorldMap = map;
            Destination = d;
        }
        protected void CalcXYDiff()
        {
            XDif = Destination.X - Owner.Location.X;
            YDif = Destination.Y - Owner.Location.Y;
        }
        public override actions.Action GetAction()
        {

            CalcXYDiff();
            int xMov = 0, yMov = 0;
            if( XDif == 0 && YDif == 0)
            {
                Complete = true;
                return new actions.Idle(Owner);
            }
            if( XDif < 0)
            {
                xMov = -1;
            }else if( XDif > 0 )
            {
                xMov = 1;
            }
            if (YDif < 0)
            {
                yMov = -1;
            }
            else if (YDif > 0)
            {
                yMov = 1;
            }

            actions.Move  ret = new actions.Move(Owner, WorldMap.GetArea(Owner.Location.X + xMov, Owner.Location.Y + yMov));
            return ret;
        }
    }
}
