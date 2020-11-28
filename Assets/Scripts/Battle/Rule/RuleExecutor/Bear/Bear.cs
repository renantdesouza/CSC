using System.Collections.Generic;
using System.Linq;

namespace Battle.Rule.RuleExecutor
{
    public class Bear: RuleExecutor
    {
        private static bool _alreadyExecuted;
        
        public override void Execute(List<HeroBattle> heroes, List<Enemy> enemies)
        {
            if (_alreadyExecuted)
            {
                return;
            }
            
            var berengar = heroes.First(h => h.IsPresent);
        
            if (!(berengar.CurrentHp < berengar.TotalHp * 0.75))
            {
                return;
            }
        
            var malu = heroes.First(h => !h.IsPresent);
            malu.IsPresent = true;
            _alreadyExecuted = true;
        }
    }
}