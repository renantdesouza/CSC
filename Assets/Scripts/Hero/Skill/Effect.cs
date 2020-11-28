using System;

namespace Hero.Skill
{
    [Serializable]
    public class Effect
    {
        public string armor;
        public string damage;
        public string dodge;
        public string hp;
        public string precision;
        public string regeneration;
        public Extra extra;
    }
}