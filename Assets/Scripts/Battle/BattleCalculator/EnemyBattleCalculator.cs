using System.Collections.Generic;
using System.Linq;
using Random = System.Random;

namespace Battle.BattleCalculator
{
    public static class EnemyBattleCalculator
    {
        private static int CalculatePrecision(Enemy enemy)
        {
            var minPrecision = enemy.level;
            var maxPrecision = enemy.level + enemy.precision;

            return new Random().Next(minPrecision, maxPrecision);
        }
        
        private static int CalculateDodge(HeroBattle hero)
        {
            var dodge = 0;
            
            foreach (var skill in hero.Skills)
            {
                if (skill.effect.dodge == null)
                {
                    continue;
                }
                
                int.TryParse(skill.effect.dodge, out var aux);
                dodge += aux;
            }
            
            var minDodge = hero.Level;
            var maxDodge = hero.Level * 2;

            return new Random().Next(minDodge, maxDodge) + dodge;
        }

        public static void Attack(HeroBattle hero, Enemy enemy)
        {
            var precision = CalculatePrecision(enemy);
            var dodge = CalculateDodge(hero);
            
            if (precision <= dodge)
            {
                return;
            }

            int attackValue;

            if (enemy.effect.Contains("-"))
            {
                var effect = enemy.effect.Split('-');
                var min = int.Parse(effect[0]);
                var max = int.Parse(effect[1]);

                attackValue = new Random().Next(min, max) + enemy.level;
            }
            else
            {
                int.TryParse(enemy.effect, out attackValue);
            }

            var armor = 0;
            
            foreach (var skill in hero.Skills)
            {
                if (skill.effect.armor == null)
                {
                    continue;
                }
                
                int.TryParse(skill.effect.armor, out var aux);
                armor += aux;
            }

            hero.CurrentHp -= (attackValue - armor);
        }

        public static HeroBattle GetHero(List<HeroBattle> heroes, Enemy enemy)
        {
            if (enemy.type.Equals(EnemyType.Irrational))
            {
                return GetHeroWhenIrrationalEnemyIsAttacking(heroes, enemy);
            }
            
            // ReSharper disable once ConvertIfStatementToReturnStatement
            if (enemy.type.Equals(EnemyType.Rational))
            {
                return GetHeroWhenRationalEnemyIsAttacking(heroes);
            }

            return null;
        }
        
        private static HeroBattle GetHeroWhenIrrationalEnemyIsAttacking(IReadOnlyList<HeroBattle> heroes, Enemy enemy)
        {
            if (enemy.currentHp < enemy.totalHp * 0.75)
            {
                var heroesPresentInTheBattle = heroes.ToList().FindAll(h => h.IsPresent);
                var heroWhoGaveTheStrongestAttackIsPresent = heroesPresentInTheBattle
                    .Any(h => BattleManager.HeroWhoGaveTheStrongestAttack.Name.Equals(h.Name));
                
                if (heroWhoGaveTheStrongestAttackIsPresent)
                {
                    return BattleManager.HeroWhoGaveTheStrongestAttack;
                }

                return heroesPresentInTheBattle[0];
            }

            var count = heroes.Count;
            var index = new Random().Next(0, count - 1);
            return heroes[index];
        }

        private static HeroBattle GetHeroWhenRationalEnemyIsAttacking(List<HeroBattle> heroes)
        {
            var heroesWithLessThen50PercentHp = heroes.FindAll(h => h.CurrentHp < h.TotalHp * 0.5);
            
            var count = 1;
            
            if (heroesWithLessThen50PercentHp.Count == 0)
            {
                count = heroes.Count;
            }

            if (heroesWithLessThen50PercentHp.Count > 1)
            {
                count = heroesWithLessThen50PercentHp.Count;
            }
            
            var index = new Random().Next(0, count - 1);

            return heroes[index];
        }

    }
}