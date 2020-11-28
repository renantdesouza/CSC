using System.Collections.Generic;

namespace Village
{
    public class DuelDrawerEnemyOptions
    {
        public static List<Enemy> DrawEnemies()
        {
            var enemyList = new List<Enemy>()
            {
                new Enemy()
                {
                    name = "Javali",
                    image = "AntiBerengar-1",
                    totalHp = 140,
                    currentHp = 140,
                    level = 12,
                    effect = "2-6",
                    precision = 4,
                    armor = 0,
                    type = "RATIONAL",
                    isPresent = true
                }
            };
                
            return enemyList;
        }
    }
}