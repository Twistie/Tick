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
        protected ISaveLoad SaveLoad;
        public Character(ISaveLoad saveLoad, string name, float str, float hp, float intel, float agi, float spd)
        {
            SaveLoad = saveLoad;
            Name = name;
            Str = str;
            Hp = hp;
            Intel = intel;
            Agi = agi;
            Spd = spd;
        }

        interface IFightable
        {
            public void takeDamage();
            public void isAlive();
            public void doCombatTick();
        }

        public new void StartSave()
        {
            SaveLoad.StartChar(this);
        }

        public new void EndSave()
        {
            SaveLoad.EndChar();
        }
    }
}
