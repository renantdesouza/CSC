using Battle;
using Hero.Level;
using Hero.Skill;

namespace Hero.Status
{
    public class StatusService
    {

        private static StatusService _instance;
        private readonly StatusResource StatusResource;

        private StatusService()
        {
            StatusResource = StatusResource.GetInstance();
        }

        public static StatusService GetInstance()
        {
            return _instance ?? (_instance = new StatusService());
        }

        public Status GetStatusFrom(string heroName)
        {
            return StatusResource.GetStatusFrom(heroName);
        }

        public void Save(HeroBattle hero)
        {
            var data = GetStatusFrom(hero.Name);
            data.currentHp = hero.CurrentHp;
            data.xp = hero.Xp;

            StatusResource.Save(hero.Name, data);
        }

        public void Save(string heroName, Status status)
        {
            StatusResource.Save(heroName, status);
        }

        public int GetPoints(string heroName)
        {
            var data = GetStatusFrom(heroName);
            return data.points;
        }

        public void ConsumeTheNecessaryPoints(string heroName, KnowledgeLevel level)
        {
            var data = GetStatusFrom(heroName);
            data.points -= level.NecessaryPoints;

            StatusResource.Save(heroName, data);
        }

        public void Reinitialize()
        {
            
        }
    }
}