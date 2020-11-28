using System.Collections.Generic;

namespace Battle.Rule.RuleExecutor
{
    public class Wolf: RuleExecutor
    {
        private static int _counter = 5;
        
        public override void Execute(List<HeroBattle> heroes, List<Enemy> enemies)
        {
            if (_counter == 0)
            {
                heroes.ForEach(h => h.CurrentHp = 0);
            }

            _counter--;
        }
    }
}