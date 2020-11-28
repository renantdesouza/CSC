using System;
using System.Collections.Generic;

namespace Battle
{
    [Serializable]
    public class Battle
    {
        public string background;

        public string backgroundSound;

        public string colorMenu;

        public string gameOverRule;

        public List<Rule.Rule> rules;

        public List<HeroBattleInfo> players;

        public List<Enemy> enemies;

        public string battleType;

        public bool isAlreadyExecuted;

        public string whereToGoWhenTheBattleIsOver;
    }
}