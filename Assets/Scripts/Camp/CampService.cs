using System.Collections.Generic;
using Battle;

public class CampService
{
    private static CampService _instance;
    private readonly BattleService BattleService;

    private CampService()
    {
        BattleService = BattleService.GetInstance();
    }
    
    public static CampService GetInstance() => _instance ?? (_instance = new CampService());

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

        hero = new HeroBattleInfo()
        {
            name = "Brayan",
            thumbnail = "DruidaCajadoVinha",
            isPresent = true
        };
        
        heroes.Add(hero);

        hero = new HeroBattleInfo()
        {
            name = "Malu",
            thumbnail = "Arqueira",
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
            backgroundSound = "Aventura",
            colorMenu = "2CDAC5",
            gameOverRule = "WHEN_EVERYONE_DIES",
            whereToGoWhenTheBattleIsOver = "Camp",
            players = BuildHeroesBattleInfo(),
            enemies = ForestDrawerEnemyOption.DrawEnemies()
        });
        BattleManager.Init();
    }
}