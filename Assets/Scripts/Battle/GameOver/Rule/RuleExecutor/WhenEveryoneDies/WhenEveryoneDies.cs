using System.Collections.Generic;
using System.Linq;

namespace Battle.GameOver.Rule
{
    public class WhenEveryoneDies: RuleExecutor
    {
        public override bool Execute(object obj)
        {
            var heroes = (List<HeroBattle>) obj;
            return heroes.All(h => h.CurrentHp <= 0);
        }
    }
}