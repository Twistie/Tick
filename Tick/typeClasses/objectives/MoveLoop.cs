using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tick.typeClasses.objectives
{
    public class MoveLoop : Objective
    {
        protected int XDif, YDif;
        protected readonly Area[] Destination;
        protected readonly IWorld WorldMap;
        protected int curDest;
        public MoveLoop(Entity o, Area[] d, IWorld map) : base(o)
        {
            WorldMap = map;
            Destination = d;
            curDest = 0;
        }
        protected void CalcXYDiff()
        {
            XDif = Destination[curDest].X - Owner.Location.X;
            YDif = Destination[curDest].Y - Owner.Location.Y;
        }
        public override actions.Action GetAction()
        {
            CalcXYDiff();
            int xMov = 0, yMov = 0;
            if( XDif == 0 && YDif == 0)
            {
                curDest++;
                if (curDest >= Destination.Length)
                {
                    curDest = 0;
                }
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
