using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tick.typeClasses
{
    public class Mob : Character
    {
        public Mob( ISaveLoad saveLoad, ILogger logger, float s, float i, float h, float a, float sp, String n ) : base(saveLoad, logger, n, s, h, i, a, sp, 0 )
        {
            Str = s;
            Intel = i;
            Hp = h;
            Agi = a;
            Spd = sp;
            Name = n;
        }
    }
}
