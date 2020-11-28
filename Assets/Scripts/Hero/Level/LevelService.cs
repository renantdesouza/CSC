using System.Collections.Generic;
using Hero.Class;
using Hero.Status;

namespace Hero.Level
{
    public class LevelService
    {
        private static LevelService _instance;
        private readonly LevelResource LevelResource;
        private readonly StatusService StatusService;
        private readonly ClassService ClassService;

        private Dictionary<int, int> Dictionary;

        private LevelService()
        {
            LevelResource = LevelResource.GetInstance();
            StatusService = StatusService.GetInstance();
            ClassService = ClassService.GetInstance();
            Dictionary = new Dictionary<int, int>()
            {
                {
                    2, 10
                },
                {
                    3, 35
                },
                {
                    4, 80
                },
                {
                    5, 150
                },
                {
                    6, 250
                },
                {
                    7, 385
                },
                {
                    8, 560
                },
                {
                    9, 780
                },
                {
                    10, 1050
                }
            };
        }

        public static LevelService GetInstance() => _instance ?? (_instance = new LevelService());

        public Level GetLevelFrom(string heroName)
        {
            return LevelResource.GetLevelFrom(heroName);
        }

        public void Save(string heroName, int xpGained)
        {
            var level = GetLevelFrom(heroName);
            var status = StatusService.GetStatusFrom(heroName);
            var @class = ClassService.GetClassFrom(heroName);

            var oldLevel = level.value;
            
            level.value = CountLevel(level.value, status.xp);
            LevelResource.Save(heroName, level);

            status.xp += xpGained;
            status.currentHp = level.value * @class.hpByLevel;
            
            if (oldLevel != level.value)
            {
                status.points += 2;
            }

            StatusService.Save(heroName, status);
        }

        private int CountLevel(int level, int xp)
        {
            if (Dictionary[level + 1] <= xp)
            {
                level += 1;
            }

            return level;
        }

        public void Reinitialize()
        {
            
        }
    }
}