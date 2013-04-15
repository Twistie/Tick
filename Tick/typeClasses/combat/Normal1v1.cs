using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tick.typeClasses
{
    class Normal1v1 : ICombat
    {
        private Character _fightA { get; set; }
        private Character _fightB { get; set; }
        private bool _isFinished = false;

        public Normal1v1(ILogger logger, Character a, Character b)
        {
            _fightA = a;
            _fightB = b;
            _logger = logger;
        }

        public override List<Character> getOpponents(Character c)
        {
            List<Character> retList = new List<Character>();
            
            retList.Add(c == _fightA ? _fightB : _fightA);

            return retList;
        }
        public override void DoTick()
        {
            if (_fightA.Agi > _fightB.Agi)
            {
                _fightA.doCombatTick();
                _fightB.doCombatTick();
            }
            else
            {
                _fightB.doCombatTick();
                _fightA.doCombatTick();
            }
            if (!_fightA.isAlive() )
            {
                _fightA.LeaveCombat();
                _fightB.LeaveCombat();
                _isFinished = true;
                _logger.Log(String.Format("{0} just died in combat with {1}", _fightA.Name, _fightB.Name));
            }
            if (!_fightB.isAlive())
            {
                _fightA.LeaveCombat();
                _fightB.LeaveCombat();
                _isFinished = true;
                _logger.Log(String.Format("{0} just died in combat with {1}", _fightB.Name, _fightA.Name));
            }
            
        }

         public override bool IsFinished()
        {
            return _isFinished;
        }
    }
}
