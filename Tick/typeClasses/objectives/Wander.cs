using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tick.typeClasses.objectives
{
    class Wander : Objective
    {
        protected int XDif, YDif;
        protected Area curDest;
        protected readonly IWorld WorldMap;
        Random random = new System.Random();
        public Wander(Entity o, IWorld map) : base(o)
        {
            WorldMap = map;

            curDest = WorldMap.GetArea(random.Next(10), random.Next(10));
        }

        protected void CalcXYDiff()
        {
            XDif = curDest.X - Owner.Location.X;
            YDif = curDest.Y - Owner.Location.Y;
        }

        public override actions.Action GetAction()
        {
            CalcXYDiff();
            int xMov = 0, yMov = 0;
            while( XDif == 0 && YDif == 0)
            {
                curDest = WorldMap.GetArea(random.Next(10), random.Next(10));
                CalcXYDiff();
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
