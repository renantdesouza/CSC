using Battle;
using Util;

public class BattleResource: Resource<Battle.Battle>
{
    private const string BATTLE_SAVE = "Assets/Resources/Data/Battle/save.json";
    private const string BATTLES = "Assets/Resources/Data/Battle/battle.json";
    private const string INIT = "Assets/Resources/Data/Battle/battle-init.json";
    
    private static BattleResource _instance;

    private BattleResource()
    {
    }

    public static BattleResource GetInstance()
    {
        return _instance ?? (_instance = new BattleResource());
    }

    public BattleSave LoadBattleDataSaveOptions()
    {
        return Get<BattleSave>(BATTLE_SAVE);
    }

    public Battle.Battle[] LoadBattles()
    {
        return Get<BattleContainer>(BATTLES).battles;
    }

    public Battle.Battle[] LoadBattlesInit()
    {
        return Get<BattleContainer>(INIT).battles;
    }

    public void SaveBattles(BattleContainer battleContainer)
    {
        base.Save(BATTLES, battleContainer);
    }

    public void Save(BattleSave data)
    {
        base.Save(BATTLE_SAVE, data);
    }

    // TODO BUSCAR OS ITENS QUE O PLAYER CARREGA
    public static void LoadPlayerInventory(Hero.Hero hero)
    {
    }

    // TODO SALVAR OS ITENS QUE O PLAYER CARREGA
    public static void SavePlayerInventory(string player)
    {
    }

    // TODO BUSCAR AS SKILLS QUE O PLAYER CARREGA
    public static void LoadPlayerSkills(string player)
    {
    }

    // TODO SALVAR AS SKILLS QUE O PLAYER TEM
    public static void SavePlayerSkills(string player)
    {
    }

    // TODO BUSCAR OS PONTOS DE VIDA DO PLAYER E MARCADORES DE MALDIÇÃO E POÇÕES
    public static void LoadPlayerStatus(string player)
    {
    }

    // SALVAR OS PONTOS DE VIDA E MARCADORES DO PLAYER
    public static void SavePlayerStatus(string player)
    {
    }
    
    // TODO BUSCAR REGRAS QUE DA BATALHA
    public static void LoadBattleRules(string battle)
    {
    }

    // TODO SALVA O ANDAR DA BATALHA
    public static void SaveBattleStatus(string battle)
    {
    }

}