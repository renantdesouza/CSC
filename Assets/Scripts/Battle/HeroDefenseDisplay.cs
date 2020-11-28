using System.Collections.Generic;

namespace Battle
{
    public class HeroDefenseDisplay
    {
        public readonly string DisplayContainerName;
        public readonly string[] ContainerNames;

        private static readonly List<HeroDefenseDisplay> HeroDefenseDisplays = new List<HeroDefenseDisplay>()
        {
            new HeroDefenseDisplay("OneHero", "FirstHero"),
            new HeroDefenseDisplay("TwoHeroes", "FirstHero", "SecondHero"),
            new HeroDefenseDisplay("ThreeHeroes", "FirstHero", "SecondHero", "ThirdHero")
        };

        private HeroDefenseDisplay(string displayContainerName, params string[] containerNames)
        {
            DisplayContainerName = displayContainerName;
            ContainerNames = containerNames;
        }

        public static HeroDefenseDisplay Get(int index)
        {
            return HeroDefenseDisplays[index];
        }
    }
}