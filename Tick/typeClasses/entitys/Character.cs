using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tick.typeClasses
{
    public class Character
    {

        public String Name { get; set; }
        public float Str { get; set; }
        public float Hp { get; set; }
        public float Intel { get; set; }
        public float Agi { get; set; }
        public float Spd { get; set; }
        public ICombat Combat { get; set; }
        public Boolean IsInCombat { get; set; }
        protected ISaveLoad SaveLoad;
        protected ILogger _logger;

        public Character(ISaveLoad saveLoad, ILogger logger, string name, float str, float hp, float intel, float agi, float spd)
        {
            _logger = logger;
            SaveLoad = saveLoad;
            Name = name;
            Str = str;
            Hp = hp;
            Intel = intel;
            Agi = agi;
            Spd = spd;
        }



        public void takeDamage(float dam){
            Hp = Math.Max(0, Hp - dam);
        }

        public bool isAlive(){ 
            return Hp <= 0 ? false: true;
        }
        
        public void doCombatTick()
        {
            Combat.getOpponents(this).First().takeDamage(Str);
            _logger.Log(String.Format("{0} did {1} damage to {2}", Name, Str, Combat.getOpponents(this).First().Name));
        }

        public new void StartSave()
        {
            SaveLoad.StartChar(this);
        }

        public new void EndSave()
        {
            SaveLoad.EndChar();
        }

        public void JoinCombat(ICombat c)
        {
            IsInCombat = true;
            Combat = c;
        }
        public void LeaveCombat()
        {
            Combat = null;
            IsInCombat = false;
        }
    }
}
