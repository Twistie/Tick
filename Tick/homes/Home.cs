using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tick.homes
{
    class Home : IBase
    {
        ILogger _logger;
        ISaveLoad _saveload;
        ICube[,,] cubeMatrix;
        
        public Home(ILogger logger, ISaveLoad saveload ) {
            int houseSize = 20;
            _logger = logger;
            _saveload = saveload;
            cubeMatrix = new ICube[20, 20, 20];

            for ( int x = 0; x < houseSize; x ++ ) {
                for ( int y = 0; y < houseSize; y ++ ) {
                    for (int z = 0; z < houseSize; z++) {
                        cubeMatrix[x, y, z] = new Cube();
                    }
                }
            }
        }
        public ICube getCube( int x,int y, int z) {
            return null;
        }
    }
}
