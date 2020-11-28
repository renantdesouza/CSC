using System.Linq;
using Battle;
using BusinessException;
using Hero.Level;
using Hero.Status;

namespace Hero
{
    public class HeroService
    {
        private static HeroService _instance;
        private readonly Skill.SkillService SkillService;
        private readonly Item.ItemService ItemService;
        private readonly Class.ClassService ClassService;
        private readonly LevelService LevelService;
        private readonly StatusService StatusService;
        
        private HeroService()
        {
            SkillService = Skill.SkillService.GetInstance();
            ItemService = Item.ItemService.GetInstance();
            ClassService = Class.ClassService.GetInstance();
            LevelService = LevelService.GetInstance();
            StatusService = StatusService.GetInstance();
        }

        public static HeroService GetInstance() => _instance ?? (_instance = new HeroService());

        public HeroBattle[] LoadHeroesInBattle(Battle.Battle battle)
        {
            return (battle.players ?? throw new CannotLoadHeroesException())
                .ToList()
                .ConvertAll(player => BuildHero(player.name, player.isPresent, player.thumbnail))
                .ToArray();
        }

        public HeroBattle LoadHero(string heroName)
        {
            return BuildHero(heroName, true, heroName);
        }


        public void Reinitialize()
        {
            ClassService.Reinitialize();
            LevelService.Reinitialize();
            StatusService.Reinitialize();
        }

        public HeroBattle BuildHero(string heroName, bool isPresent, string thumbnail)
        {
            var @class = ClassService.GetClassFrom(heroName);
            var level = LevelService.GetLevelFrom(heroName).value;
            var status = StatusService.GetStatusFrom(heroName);
            
            var hp = @class.hpByLevel * level;

            var inventory = ItemService.GetInventoryFrom(heroName);

            var skills = (SkillService
                    .GetSkillsFrom(heroName) ?? throw new CannotLoadSkillsException(heroName))
                .ToList()
                .ConvertAll(sk => SkillService.GetSkillByName(sk.skill)).ToArray();
               
            return hp <= 0 ? null : new HeroBattle
            {
                Name = heroName,
                Class = @class,
                Thumbnail = thumbnail,
                Level = level,
                IsPresent = isPresent,
                Skills = skills,
                Inventory = inventory,
                TotalHp = hp,
                CurrentHp = status.currentHp,
                Xp = status.xp
            };
        }
    }
}