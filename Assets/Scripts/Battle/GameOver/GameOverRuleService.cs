using System.Collections.Generic;
using Battle.GameOver.Rule;

namespace Battle.GameOver
{
    public class GameOverRuleService
    {
        private static GameOverRuleService _instance;
        private static Dictionary<string, RuleExecutor> _dict;

        private GameOverRuleService()
        {
            _dict = new Dictionary<string, RuleExecutor>()
            {
                {GameOverRuleType.WhenSomeoneDies, new WhenSomeoneDies()},
                {GameOverRuleType.WhenEveryoneDies, new WhenEveryoneDies()}
            };
        }

        public static GameOverRuleService GetInstance() => _instance ?? (_instance = new GameOverRuleService());

        public bool Test(string ruleName, object param)
        {
            var rule = _dict[ruleName];
            return rule.Execute(param);
        }
    }
}