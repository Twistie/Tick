﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tick.typeClasses
{
    public class Mob : Character
    {
        public Mob( ISaveLoad saveLoad, float s, float i, float h, float a, float sp, String n ) : base(saveLoad, n, s, h, i, a, sp )
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
