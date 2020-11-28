using System;
using System.Collections.Generic;

public static class ForestDrawerEnemyOption
{
    private const string TwoBoars = "TwoBoars";
    private const string Boar = "Boar";
    private const string Bison = "Bison";
    private const string None = "None";
    
    private static readonly Dictionary<string, List<Enemy>> Dictionary = new Dictionary<string, List<Enemy>>()
    {
        {
            Boar, new List<Enemy>()
            {
                new Enemy()
                {
                    name = "Javali",
                    image = "Javali-1",
                    totalHp = 10,
                    currentHp = 10,
                    level = 2,
                    effect = "1-5",
                    precision = 5,
                    armor = 3,
                    type = "IRRATIONAL",
                    isPresent = true
                }
            }
        },
        {
            TwoBoars, new List<Enemy>()
            {
                new Enemy()
                {
                    name = "Javali",
                    image = "Javali-1",
                    totalHp = 10,
                    currentHp = 10,
                    level = 2,
                    effect = "1-5",
                    precision = 5,
                    armor = 3,
                    type = "IRRATIONAL",
                    isPresent = true
                },
                new Enemy()
                {
                    name = "Javali",
                    image = "Javali-1",
                    totalHp = 10,
                    currentHp = 10,
                    level = 2,
                    effect = "1-5",
                    precision = 5,
                    armor = 3,
                    type = "IRRATIONAL",
                    isPresent = true
                }
            }
        },
        {
            Bison, new List<Enemy>()
            {
                new Enemy()
                {
                    name = "Bisão",
                    image = "BisaoEuropeu-1",
                    totalHp = 25,
                    currentHp = 25,
                    level = 4,
                    effect = "2-8",
                    precision = 6,
                    armor = 2,
                    type = "IRRATIONAL",
                    isPresent = true
                }
            }
        },
        {
            None, null
        }
    };
    
    public static List<Enemy> DrawEnemies()
    {
        var enemyList = new List<Enemy>();

        AddRange(enemyList, Bison, Boar, Boar);
        AddRange(enemyList, TwoBoars, Boar, None);
        
        return enemyList;
    }

    private static void AddRange(List<Enemy> enemyList, params string[] enemies)
    {
        var index = new Random().Next(0, enemies.Length);
        var key = enemies[index] ?? None;

        if (Dictionary[key] != null)
        {
            enemyList.AddRange(Dictionary[key]);
        }
    }
}
