using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tick.messages;
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
        private ILogger _logger;
        public Character _char  { get; set; }
        public Entity(Area l, ILogger logger, ISaveLoad saveLoad, int id)
        {
            ID = id;
            _logger = logger;
            SaveLoad = saveLoad;
            Location = l;
            CurObjective = new objectives.Idle(this);
            CurAction = CurObjective.GetAction();
            _char = new Character(saveLoad, logger, "Ted", 20, 200, 20, 20, 20, this.ID);
        }

        public void DoTick()
        {
            if (_char.IsInCombat)
                return;
            if (!_char.isAlive())
            {
                _char.CurHp = _char.Hp;
                _logger.Log(new StatusMessage(_char));
                _logger.Log("Ted died and had to be revived. Poor Ted.");
                return;
            }
            if( CurObjective.Complete)
                CurObjective = new objectives.Idle(this);

            if (CurAction.Complete)
                CurAction = CurObjective.GetAction();

            CurAction.DoTick();
        }

        public void Move(Area d)
        {
            _logger.Log(new MoveMessage(this, Location, d));
            Location.RemoveEntity(this);
            Location = d;
            _logger.Log(String.Format("{0} moved to {1}", _char.Name, d.ToString()));
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
