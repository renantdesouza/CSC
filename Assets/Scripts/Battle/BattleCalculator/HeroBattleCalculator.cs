using System.Collections.Generic;
using System.Linq;
using BusinessException;
using Hero.Item;
using Hero.Level;
using Random = System.Random;

namespace Battle.BattleCalculator
{
    public static class HeroBattleCalculator
    {
        private static readonly LevelService LevelService = LevelService.GetInstance();

        private static int CalculatePrecision(HeroBattle hero, Item item)
        {
            var skillPrecision = 0;
                
            foreach (var skill in hero.Skills)
            {
                if (skill.effect.precision == null)
                {
                    continue;
                }
                
                int.TryParse(skill.effect.precision, out var aux);
                skillPrecision += aux;
            }

            int weaponPrecision;

            if (item.precision != null)
            {
                int.TryParse(item.precision, out weaponPrecision);
            }
            else
            {
                weaponPrecision = 0;
            }

            var minPrecision = hero.Level;
            var maxPrecision = hero.Level + weaponPrecision;

            return new Random().Next(minPrecision, maxPrecision) + skillPrecision;
        }

        private static int CalculateDodge(Enemy enemy)
        {
            var minDodge = enemy.level;
            var maxDodge = enemy.level * 2;
            
            return new Random().Next(minDodge, maxDodge);
        }

        public static void Attack(HeroBattle hero, Enemy enemy)
        {
            var item = hero.Inventory.FirstOrDefault(it => it.type.Equals(ItemType.Weapon) && it.isEquipped);

            if (item == null)
            {
                throw new CannotFindEquippedItemException();
            }
            
            var precision = CalculatePrecision(hero, item);
            var dodge = CalculateDodge(enemy);
            
            if (precision <= dodge)
            {
                return;
            }

            int attackValue;

            if (item.effect.Contains('-'))
            {
                var effect = item.effect.Split('-');
                var min = int.Parse(effect[0]);
                var max = int.Parse(effect[1]);

                attackValue = new Random().Next(min, max) + hero.Level;
            }
            else
            {
                int.TryParse(item.effect, out attackValue);
            }

            enemy.currentHp -= (attackValue - enemy.armor);
        }

        public static void CalculateTheExperienceGained(List<HeroBattle> heroes, List<Enemy> enemies)
        {
            var xpGained = enemies.Select(e => e.level).Sum();

            heroes.ForEach(h => LevelService.Save(h.Name, xpGained));
        }

    }
}