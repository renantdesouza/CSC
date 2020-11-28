using System.Collections.Generic;
using System.Linq;

namespace Battle.GameOver.Rule
{
    public class WhenSomeoneDies: RuleExecutor
    {
        public override bool Execute(object obj)
        {
            var heroes = (List<HeroBattle>) obj;
            return heroes.Any(h => h.CurrentHp <= 0);
        }
    }
}