using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;
using Tick.typeClasses;
namespace Tick.factorys
{
    class MobFact
    {
        public float StrMin { get; set; }
        public float StrMax { get; set; }
        public float IntMax { get; set; }
        public float IntMin { get; set; }
        public float AgiMin { get; set; }
        public float AgiMax { get; set; }
        public float HpMin { get; set; }
        public float HpMax { get; set; }
        public String Name { get; set; }
        private ISaveLoad _saveLoad;
        protected ILogger _log { get; set; }
        private StandardKernel _inject;

        public MobFact( ISaveLoad saveLoad, StandardKernel inject, ILogger log, float sMin, float sMax,float iMin, float iMax,float aMin, float aMax,float hMin, float hMax, String n)
        {
            _inject = inject;
            _saveLoad = saveLoad;
            StrMax = sMax;
            StrMin = sMin;
            IntMax = iMax;
            IntMin = iMin;
            AgiMax = aMax;
            AgiMin = aMin;
            HpMax = hMax;
            HpMin = hMin;
            Name = n;
            _log = log;
        }

        public Mob CreateMob()
        {
            Mob m = new Mob(_saveLoad, _log, StrMax, IntMax, HpMax, AgiMax, 10.0f, Name);
            return m;
        }
    }
}
