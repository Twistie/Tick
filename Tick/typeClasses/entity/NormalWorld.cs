using System;
using Ninject;
using Tick.factorys;
using Tick;

namespace Tick.typeClasses
{
    [Serializable]
    class NormalWorld : IWorld
    {
        private readonly ILogger _logger;
        private StandardKernel _inject;
        public int Size;
        private readonly Area[,] _world;
        private ISaveLoad _saveLoad;
       
       public NormalWorld( ILogger logger, StandardKernel inject ,  ISaveLoad saveLoad, int size )
       {
           _saveLoad = saveLoad;
           _logger = logger;
           _inject = inject;
           Size = size;

           AreaFact af = new AreaFact(saveLoad, _inject);
           _world = new Area[20, 20];
           for (int i = 0; i < 20; i++)
           {
               for (int j = 0; j < 20; j++)
               {
                   _world[i, j] = af.CreateArea(i, j);
               }
           }
           _logger.Log("Areas Generated");
       }

        public void DoTick()
        {
            return;
        }

        public Area GetArea(int x, int y)
        {
            return _world[x, y];
        }
    }
}
