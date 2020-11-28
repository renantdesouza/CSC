using System.Collections.Generic;
using Battle.Rule.RuleExecutor;

namespace Battle.Rule
{
    public class RuleService
    {
        private static RuleService _instance;

        private readonly Dictionary<string, RuleExecutor.RuleExecutor> Dictionary;

        private RuleService()
        {
            Dictionary = new Dictionary<string, RuleExecutor.RuleExecutor>()
            {
                {RuleName.Bear, new Bear()},
                {RuleName.Wolf, new Wolf()}
            };
        }

        public static RuleService GetInstance()
        {
            return _instance ?? (_instance = new RuleService());
        }

        public RuleExecutor.RuleExecutor Get(string ruleName)
        {
            return Dictionary[ruleName];
        }
    }
}