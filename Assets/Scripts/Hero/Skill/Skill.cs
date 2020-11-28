using System;

namespace Hero.Skill
{
    [Serializable]
    public class Skill
    {
        public string name;
        public string[] usedBy;
        public Effect effect;
        public string[] requirements;
        public string type;
        public string description;
    }
}