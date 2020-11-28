using System.Linq;
using Battle;
using Battle.BattleCalculator;
using BusinessException;

public class BattleService
{
    private static BattleService _instance;
    private static BattleResource _battleResource;

    private BattleService()
    {
        _battleResource = BattleResource.GetInstance();
    }

    public static BattleService GetInstance()
    {
        return _instance ?? (_instance = new BattleService());
    }

    public BattleSave LoadData()
    {
        return _battleResource.LoadBattleDataSaveOptions();
    }

    public Battle.Battle[] LoadBattle()
    {
        return _battleResource.LoadBattles();
    }

    public void Attack(HeroBattle hero, Enemy enemy)
    {
        HeroBattleCalculator.Attack(hero, enemy);
    }

    public void Save(int index)
    {
        var data = new BattleSave()
        {
            currentBattle = index
        };
        
        _battleResource.Save(data);
    }

    public void AddBattle(Battle.Battle battle)
    {
        var battleArray = LoadBattle();
        var battles = (battleArray ?? throw new CannotLoadBattleFileException()).ToList();

        battles.Add(battle);

        var data = new BattleContainer()
        {
            battles = battles.ToArray()
        };
        
        _battleResource.SaveBattles(data);
        
        Save(battles.Count - 1);
    }
    
    public void Reinitialize()
    {
        var battleArray = _battleResource.LoadBattlesInit();
        var battles = (battleArray ?? throw new CannotLoadBattleFileException()).ToList();
        
        var data = new BattleContainer()
        {
            battles = battles.ToArray()
        };
        
        _battleResource.SaveBattles(data);
    }
}
    
    