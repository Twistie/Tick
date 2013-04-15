using System.Linq;
using System.Windows.Forms;
using Tick.typeClasses;

namespace Tick.IO.testUI
{
    public partial class Map : Form
    {
        private readonly IWorld _worldMap;
        public Map(IWorld world)
        {
            _worldMap = world;
            InitializeComponent();
            RefreshMap();
        }

        public void RefreshMap()
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    this.mapTable[i, j].Text = _worldMap.GetArea(i, j).GetEntitys().Count() + "";
                }

            }
        }
    }
}
