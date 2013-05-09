using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Net;
using System.Windows.Forms;
using Ninject.Parameters;
using Tick.IO.testUI;
using Tick.factorys;
using Tick.typeClasses;
using Ninject;
using System.Threading;

namespace Tick
{   
    
    public partial class Tick : Form
    {
        internal NormalWorld World;
        private LinkedList<Entity> _entList;
        private readonly StandardKernel _inject;
        private ISaveLoad _saveEngine;
        private ILogger _logger;
        public Tick()
        {
            _inject = new StandardKernel();
            this.Show();
            _entList = new LinkedList<Entity>();
            InitializeComponent();
            _logger = new FleckLogger();
            _saveEngine = new MySQLSaveLoad(_logger);
            PrepareInject();
            
            GenAreas();
        }
        private void PrepareInject()
        {
            _inject.Bind<ILogger>().ToConstant(_logger);
            _inject.Bind<StandardKernel>().ToConstant(_inject);

            _inject.Bind<ISaveLoad>().ToConstant(_saveEngine);
        }
        public void DoTick()
        {
            foreach (Entity ent in _entList)
            {
                ent.DoTick();
            }
            World.DoTick();
        }

        /// <summary>
        /// Generates World Areas, placeholder till file I/O is implemented
        /// </summary>
        private void GenAreas()
        {
            World = _inject.Get<NormalWorld>(new ConstructorArgument("size", 20 ));

        }

        /// <summary> 
        /// Adds text to the logbox, primarily for debugging
        /// </summary> 
        /// <param name="toAdd">The text to be added to the log box in the main menu</param> 
        public void AddText(string toAdd)
        {
            logBox.Text = string.Format("{0}\r\n{1}", toAdd, logBox.Text);
            logBox.Invalidate();
            
        }

        /// <summary> 
        /// Threads can't write to the logbox directly, this just invokes the addtext method
        /// </summary>
        /// <param name="message">Message to be added </param>
        private void AddTextFromThread(string message)
        {
            if (this.logBox.InvokeRequired)
                this.logBox.BeginInvoke(new MethodInvoker(delegate() { AddTextFromThread(message); }));
            else
                AddText(message);
        }

        private void MapButton_Click(object sender, EventArgs e)
        {
            Map m = new Map(World);
            m.Show();
        }

        private void TestButton1_Click(object sender, EventArgs e)
        {
            _entList.AddFirst(_inject.Get<Entity>(new ConstructorArgument("l", World.GetArea(0,0))));
            World.GetArea(0, 0).AddEntity(_entList.First.Value );
            AddText("Entity Added");
        }

        private void TestButton2_Click(object sender, EventArgs e)
        {
            _entList.First.Value.CurObjective = new typeClasses.objectives.Wander( _entList.First.Value,  World);
            AddText("Objective set for first entity");
        }

        private void TickButton_Click(object sender, EventArgs e)
        {
            while (true)
            {
                DoTick();
                AddText("Tick Complete");
                Thread.Sleep(1500);
            }
        }

        public void saveState()
        {
            foreach( Entity e in _entList )
            {
                e.StartSave();
                e.EndSave();
            }
            SaveWorld();
        }

        public void SaveWorld()
        {
            for( int x = 0; x < World.Size; x ++ )
            {
                for( int y = 0; y < World.Size; y ++ )
                {
                    World.GetArea(x, y).startSave();
                    World.GetArea(x, y).endSave();
                }
            }
        }

        public List<string> ReleventLogs()
        {
            return new List<string>();
        }

        public void Log(string s)
        {
            AddText(s);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            saveState();
        }

        private void loadButton_click(object sender, EventArgs e)
        {

        }

    }
}
