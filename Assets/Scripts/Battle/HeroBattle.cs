using Hero.Class;
using Hero.Item;

namespace Battle
{
    public class HeroBattle
    {
        public string Portrait;

        public string Thumbnail;

        public string Name;

        public Class Class;

        public int Level;

        public bool IsPresent;

        public Hero.Skill.Skill[] Skills;

        public Item[] Inventory;

        public double TotalHp;

        public double CurrentHp;

        public int Xp;
    }
}