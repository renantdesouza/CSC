using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using BackgroundSound;
using Battle;
using Battle.BattleCalculator;
using Battle.GameOver;
using Battle.Rule;
using BusinessException;
using Hero;
using Hero.Item;
using SkillsViewer;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[SuppressMessage("ReSharper", "Unity.PerformanceCriticalCodeInvocation")]
public class BattleManager : MonoBehaviour
{
    private static readonly BattleService BattleService = BattleService.GetInstance();
    private readonly HeroService HeroService = HeroService.GetInstance();
    private readonly RuleService RuleService = RuleService.GetInstance();

    private string CurrentBattlePhase = BattlePhase.Attack;

    private int SelectedEnemyIndex;
    private static int _lastCurrentBattleIndex;
    private static int _currentHeroIndex;
    private static int _currentEnemyIndex;
    private static int _currentBattleIndex;
     
    private static Battle.Battle _currentBattle;
    private static List<HeroBattle> _heroes;
    private static List<Enemy> _enemies;

    public static HeroBattle HeroWhoGaveTheStrongestAttack;
    private static int _strongestAttack;
    
    // INITIAZING
    private void Awake()
    {
        Init();
        ClearEnemyList();
    }

    public static void Init()
    {
        _currentBattleIndex = BattleService.LoadData().currentBattle;
        _currentBattle = BattleService.LoadBattle()?.ToList()[_currentBattleIndex];
        
        _lastCurrentBattleIndex = -1;
        _strongestAttack = 0;
    }

    // RENDER
    private void Update()
    {
        if (_currentBattleIndex <= _lastCurrentBattleIndex)
        {
            return;
        }
        
        _heroes = HeroService.LoadHeroesInBattle(_currentBattle)?.ToList();
        _currentHeroIndex = 0;
        _currentEnemyIndex = 0;

        _enemies = _currentBattle.enemies;
        
        DrawSpriteToGameObject(_currentBattle.background, "Background");

        DrawEnemy();
        DrawMenu();
        
        BackgroundSoundManager.Play(_currentBattle.backgroundSound);

        _lastCurrentBattleIndex = _currentBattleIndex;
    }

    // ENEMY
    private static void ClearEnemyList()
    {
        Hide("OneEnemy");
        Hide("TwoEnemies");
        Hide("ThreeEnemies");
    }

    private void DrawEnemy()
    {
        var battle = _currentBattle;
        var enemyDisplay = EnemyDisplay.Get(battle.enemies.Count - 1);
        Show(enemyDisplay.DisplayContainerName);

        var count = battle.enemies.Count;

        for (var i = 0; i < count; i++)
        {
            var containerName = enemyDisplay.ContainerNames[i] + "_" + count;
            DrawSpriteToGameObject(battle.enemies[i].image, containerName);
        }
    }

    // SELECTORS
    public void OnSelectEnemy(int index)
    {
        if (_enemies[index].currentHp <= 0)
        {
            return;
        }
        
        var count = _currentBattle.enemies.Count;
        var enemyDisplay = EnemyDisplay.Get(count - 1);
        
        GetEnemiesPresentIndexes().ForEach(i =>
        {
            SetColorToGameObject(Color.white, enemyDisplay.ContainerNames[i] + "_" + count); 
        });

        SetColorToGameObject(Color.yellow, enemyDisplay.ContainerNames[index] + "_" + count);

        SelectedEnemyIndex = index;
    }

    private List<int> GetHeroesPresentIndexes()
    {
        var indexes = new List<int>();
        
        for (var i = 0; i < _heroes.Count; i++)
        {
            if (_heroes[i].IsPresent)
            {
                indexes.Add(i);
            }
        }

        return indexes;
    }
    
    private List<int> GetEnemiesPresentIndexes()
    {
        var indexes = new List<int>();
        
        for (var i = 0; i < _enemies.Count; i++)
        {
            if (_enemies[i].isPresent)
            {
                indexes.Add(i);
            }
        }

        return indexes;
    }
    
    // MENUS.
    private static void ClearMenu()
    {
       Hide("AttackMenu");
       Hide("DefenseMenu");
    }

    private void DrawMenu()
    {
        ClearMenu();

        // ReSharper disable once ConvertIfStatementToSwitchStatement
        if (CurrentBattlePhase == BattlePhase.Attack)
        {
            DrawAttackMenu();
        }
        else if (CurrentBattlePhase == BattlePhase.Defense)
        {
            DrawDefenseMenu();
        }
    }

    private void DrawAttackMenu()
    {
        Hide("DefenseMenu");
        Show("AttackMenu");
        
        var heroes = _heroes.FindAll(h => h.IsPresent);
        var currentHeroIndex = _currentHeroIndex > heroes.Count ? heroes.Count - 1 : _currentHeroIndex; 
        var hero = heroes[currentHeroIndex];
        
        DrawSpriteToGameObject(hero.Thumbnail, "Thumbnail");

        var item = hero.Inventory?.First(it => it.type.Equals(ItemType.Weapon) && it.isEquipped);
        
        DrawSpriteToGameObject(item.image, "BasicAttack");
    }
    
    private static void ClearDefenseList()
    {
        Hide("OneHero");
        Hide("TwoHeroes");
        Hide("ThreeHeroes");
    }
    
    private void DrawDefenseMenu()
    {
        ClearDefenseList();
        
        // var heroes = _heroes.FindAll(hero => hero.IsPresent);
        var count = _heroes.Count;

        Hide("AttackMenu");
        Show("DefenseMenu");
        
        var heroDefenseDisplay = HeroDefenseDisplay.Get(count - 1);
        
        Show(heroDefenseDisplay.DisplayContainerName);

        for (var i = 0; i < count; i++)
        {
            var containerName = heroDefenseDisplay.ContainerNames[i] + "_" + count;
            DrawSpriteToGameObject(_heroes[i].Thumbnail, containerName);

            SetColorToGameObject(_heroes[i].IsPresent ? Color.white : Color.black, containerName);
        }

        StartCoroutine(EnemyAttack());
    }

    private IEnumerator EnemyAttack()
    {
        yield return new WaitForSeconds(1.0f);
        // definir quem ataca
        var enemy = _enemies[_currentEnemyIndex];

        // Definir o inimigo
        var heroes = _heroes.FindAll(h => h.IsPresent);
        var hero = EnemyBattleCalculator.GetHero(heroes, enemy);

        // Executar regra pré turno
        ExecuteRule(RuleType.BeforeEnemyAttack);

        // atacar
        var hp = hero.CurrentHp;

        EnemyBattleCalculator.Attack(hero, enemy);

        // verificar se causou dano
        var heroDefenseDisplay = HeroDefenseDisplay.Get(_heroes.Count - 1);
        var index = _heroes.FindIndex(h => h.Name.Equals(hero.Name));
        var tagName = heroDefenseDisplay.ContainerNames[index] + "_" + _heroes.Count;

        if (hero.CurrentHp < hp)
        {
            for (var i = 0; i < 5; i++)
            {
                yield return new WaitForSeconds(0.2f);
                SetColorToGameObject(Color.red, tagName);

                yield return new WaitForSeconds(0.2f);
                SetColorToGameObject(Color.white, tagName);
            }
        }

        // definir personagem como morto caso a vida esteja menor ou igual a zero
        if (hero.CurrentHp <= 0)
        {
            hero.IsPresent = false;

            SetColorToGameObject(Color.black, tagName);

            _currentHeroIndex = 0;
        }

        // Verificar se existem inimigos vivos
        if (GameOverRuleService.GetInstance().Test(_currentBattle.gameOverRule, heroes))
        {
            SceneManager.LoadScene("GameOver");
            yield break;
        }

        // Executar a regra pos ataque
        ExecuteRule(RuleType.AfterEnemyAttack);

        // Se existir outros aliados continua o ataque
        if (_currentEnemyIndex + 1 == _enemies.Count)
        {
            DrawAttackMenu();
            yield break;
        }

        // se não existir outros aliados vai para a outra fase da batalha 
        _currentEnemyIndex++;
        yield return EnemyAttack();
    }

    public void OnClickChoosePotion()
    {
        throw new FeatureNotImplementedInThisVersionException();
    }

    public void BasicAttack()
    {
        StartCoroutine(HeroAttack());
    }

    private IEnumerator HeroAttack()
    {
        // definir inimigo
        var index = SelectedEnemyIndex;
        var enemy = _enemies[index];
        
        // executar regra pré ataque
        ExecuteRule(RuleType.BeforeHeroAttack);
        
        // definir quem ataca
        var heroes = _heroes.FindAll(h => h.IsPresent);
        var hero = heroes[_currentHeroIndex];
        
        // atacar
        var previousHp = enemy.currentHp;

        BattleService.Attack(hero, enemy);

        var currentHp = enemy.currentHp;
        
        // verificar se causou dano
        var enemyDisplay = EnemyDisplay.Get(_enemies.Count - 1);
        var tagName = enemyDisplay.ContainerNames[index] + "_" + _enemies.Count;

        var attackValue = previousHp - currentHp;
        
        if (_strongestAttack < attackValue)
        {
            _strongestAttack = attackValue;
            HeroWhoGaveTheStrongestAttack = hero;
        }

        if (previousHp != currentHp)
        {
            for (var i = 0; i < 5; i++)
            {
                yield return new WaitForSeconds(0.1f);
                SetColorToGameObject(Color.red, tagName);
        
                yield return new WaitForSeconds(0.1f);
                SetColorToGameObject(Color.white, tagName);
            }
        }
        
        // alterar status da vida
        if (currentHp <= 0)
        {
            enemy.isPresent = false;
            
            SetColorToGameObject(Color.black, tagName);
        }

        // verificar se existem inimigos vivos
        var thereAreEnemiesAlive = _enemies.Any(e => e.isPresent);
        
        if (!thereAreEnemiesAlive)
        {
            //TODO: Verificar se toda a equipe ganha xp, mesmo se tiver morrido.
            HeroBattleCalculator.CalculateTheExperienceGained(heroes, _enemies);


            SkillsViewerService.GetInstance().Heroes = _heroes.ConvertAll(h => h.Name).ToArray();
            SceneManager.LoadScene(_currentBattle.whereToGoWhenTheBattleIsOver);
        }
        
        // executar regra pos ataque
        ExecuteRule(RuleType.AfterHeroAttack);

        var count = heroes.FindAll(h => h.IsPresent).Count;

        // se Existir aliados continuar ataque
        if (_currentHeroIndex + 1 < count)
        {
            _currentHeroIndex++;
            DrawAttackMenu();
            yield break;
        }
        
        // ir para a próxima fase da batalha
        _currentHeroIndex = 0;
        DrawDefenseMenu();
    }

    private void ExecuteRule(string ruleType)
    {
        var rule = _currentBattle.rules?.FirstOrDefault(r => r.time.Equals(ruleType));

        if (rule == null)
        {
            return;
        }
        
        var ruleExecutor = RuleService.Get(rule.name);
        ruleExecutor.Execute(_heroes, _enemies);
    }

    // UTILITIES.
    private static void SetColorToGameObject(Color color, string gameObjectTag)
    {
        GameObject.FindGameObjectWithTag(gameObjectTag).GetComponent<Image>().color = color;
    }

    private static void DrawSpriteToGameObject(string spriteName, string gameObjectTag)
    {
        GameObject.FindGameObjectWithTag(gameObjectTag).GetComponent<Image>().sprite = LoadSpriteByName(spriteName);
    }

    private static Sprite LoadSpriteByName(string name)
    {
        return Resources.Load<Sprite>($"Sprites/Battle/{name}");
    }

    private static void Hide(string tagName)
    {
        GameObject.FindGameObjectWithTag(tagName).transform.localScale = new Vector3(0, 0, 0);
    }

    private static void Show(string tagName)
    {
        GameObject.FindGameObjectWithTag(tagName).transform.localScale = new Vector3(1, 1, 1);
    }
}