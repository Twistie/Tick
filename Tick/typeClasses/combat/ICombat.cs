using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tick.typeClasses
{
    public abstract class ICombat
    {
        protected ILogger _logger;

        public abstract List<Character> getOpponents(Character c);
        public abstract void DoTick();
        public abstract bool IsFinished();
    }
}
