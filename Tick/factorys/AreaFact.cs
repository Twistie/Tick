using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;
using Tick.typeClasses;

namespace Tick.factorys
{
    class AreaFact
    {
        private ISaveLoad _saveLoad;
        private StandardKernel _inject;
        public AreaFact( ISaveLoad saveLoad, StandardKernel inject )
        {
            _saveLoad = saveLoad;
            _inject = inject;
        }
        public Area CreateArea( int x, int y)
        {
            return _inject.Get<Area>(new Ninject.Parameters.ConstructorArgument("x", x), new Ninject.Parameters.ConstructorArgument("y", y));
        }
    }
}
