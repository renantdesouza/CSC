using System.Collections.Generic;

namespace Battle.Rule.RuleExecutor
{
    public abstract class RuleExecutor
    {
        public abstract void Execute(List<HeroBattle> heroes, List<Enemy> enemies);
    }
}