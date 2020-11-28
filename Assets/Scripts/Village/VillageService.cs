using System.Collections.Generic;
using Battle;

namespace Village
{
    public class VillageService
    {
        private static VillageService _instance;
        private static BattleService BattleService;

        private VillageService()
        {
            BattleService = BattleService.GetInstance();
        }

        public static VillageService GetInstance() => _instance ?? (_instance = new VillageService());
        
        public List<HeroBattleInfo> BuildHeroesBattleInfo()
        {
            var heroes = new List<HeroBattleInfo>();

            var hero = new HeroBattleInfo()
            {
                name = "Berengar",
                thumbnail = "GuerreiroMachado",
                isPresent = true
            };
        
            heroes.Add(hero);

            return heroes;
        }
    
        public void CreateNewBattle()
        {
            BattleService.AddBattle(new Battle.Battle()
            {
                background = "floresta certa",
                backgroundSound = "Tensao",
                colorMenu = "2CDAC5",
                gameOverRule = "WHEN_EVERYONE_DIES",
                whereToGoWhenTheBattleIsOver = "Camp",
                players = BuildHeroesBattleInfo(),
                enemies = DuelDrawerEnemyOptions.DrawEnemies()
            });
            BattleManager.Init();
        }
    }
}