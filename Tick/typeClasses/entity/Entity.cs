using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tick.typeClasses;


namespace Tick.typeClasses
{
    public class Entity
    {

        public Area Location { get; set; }
        public Entity Owner { get; set; }
        public objectives.Objective CurObjective { get; set; }
        public actions.Action CurAction { get; set; }
        public int ID { get; set; }
        protected ISaveLoad SaveLoad;

        public Entity(Area l, ISaveLoad saveLoad)
        {
            SaveLoad = saveLoad;
            Location = l;
            CurObjective = new objectives.Idle(this);
            CurAction = CurObjective.GetAction();
        }

        public void DoTick()
        {
            if( CurObjective.Complete)
                CurObjective = new objectives.Idle(this);

            if (CurAction.Complete)
                CurAction = CurObjective.GetAction();

            CurAction.DoTick();
        }

        public void Travel(Area d)
        {
            Location.RemoveEntity(this);
            Location = d;
            d.AddEntity(this);
        }
        public void StartSave()
        {
            SaveLoad.StartEntity(this, true);
        }

        public void EndSave()
        {
            SaveLoad.EndEntity();
        }
    }
}
