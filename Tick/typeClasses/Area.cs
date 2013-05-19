using System;
using System.Collections.Generic;
using Ninject;
using Tick.factorys;
using Tick.messages;


namespace Tick.typeClasses
{
    public class Area
    {
        public String Name { get; set; }
        public float MobCount { get; set; }
        public float TravelTime { get; set; }
        private LinkedList<ICombat> _combatList;
        private LinkedList<MobFact> MobFacts;
        private List<Entity> _entHere;
        public int X { get; set; }
        public int Y { get; set; }
        private ISaveLoad _saveLoad;
        private StandardKernel _inject;
        private ILogger _logger;
        
        public Area(ISaveLoad saveLoad, StandardKernel inject, ILogger logger, int x, int y)
        {
            _logger = logger;
            _saveLoad = saveLoad;
            _inject = inject;
            Random rand = new Random();
            _entHere = new List<Entity>();
            _combatList = new LinkedList<ICombat>();
            X = x;
            Y = y;
            Name = "Plains";
            TravelTime = rand.Next(1, 10);
            MobFacts = new LinkedList<MobFact>();
            MobCount = 50f;
            MobFacts.AddFirst(new MobFact(_saveLoad, _inject, logger, 10, 10, 10, 10, 10, 10, 50, 50, "Herman"));
        }
        /// <summary>
        /// Checks whether an attempt to travel by Entity c is successful
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public bool TravelAttempt(Entity e)
        {
            return true;
        }
        /// <summary>
        /// Checks whether a fight is started by a char in this area
        /// </summary>
        /// <returns></returns>
        public bool IsFight( Entity e )
        {
            Random a = new System.Random();
            if (a.Next(10) > 8)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Gets a mob for an entity to fight (usually if IsFight returns true)
        /// </summary>
        /// <returns></returns>
        public Mob GetMob()
        {
            return MobFacts.First.Value.CreateMob();
        }
        public bool RemoveEntity( Entity e )
        {
            return _entHere.Remove(e);
        }
        public void AddEntity( Entity e )
        {
            _entHere.Add(e);
        }

        public void DoTick()
        {
            for(int i = 0; i < _entHere.Count ;i ++)
            {
                Entity ent = _entHere[i];
                if (!ent._char.IsInCombat)
                {
                    if (IsFight(ent))
                    {
                        _logger.Log(String.Format("{0} just got into a fight!!", ent._char.Name));
                        Mob m = MobFacts.First.Value.CreateMob();
                        ICombat comb = new Normal1v1(_logger, ent._char, m);
                        m.Combat = comb;
                        ent._char.JoinCombat(comb);
                        _combatList.AddLast(comb);
                    }
                }
            }
            LinkedList<ICombat> toRemove = new LinkedList<ICombat>();
            foreach (ICombat c in _combatList)
            {

                if (c.IsFinished())
                {
                    toRemove.AddFirst(c);
                }
                else
                {
                    c.DoTick();

                }
            }
            foreach (ICombat c in toRemove)
            {
                _combatList.Remove(c);
            }
        }
        public Entity[] GetEntitys()
        {
            Entity[] ret = new Entity[_entHere.Count];
            _entHere.CopyTo(ret, 0);
            return ret;
        }
        public void startSave()
        {
            _saveLoad.StartArea(X, Y);
        }
        public void endSave()
        {
            _saveLoad.EndArea();
        }
        public override string ToString()
        {
            return String.Format("{0} at X:{1}, Y:{2}", Name, X, Y);
        }
    }
}
