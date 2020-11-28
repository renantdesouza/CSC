using System.Collections.Generic;
using System.Linq;
using Hero.Class;
using Hero.Skill;

namespace SkillsViewer
{
    public class SkillsViewerService
    {
        private static SkillsViewerService _instance;
        private readonly SkillViewerResource SkillViewerResource;
        private readonly SkillService SkillService;
        private readonly ClassService ClassService;
        
        public string[] Heroes;

        private SkillsViewerService()
        {
            SkillViewerResource = SkillViewerResource.GetInstance();
            SkillService = SkillService.GetInstance();
            ClassService = ClassService.GetInstance();
        }

        public static SkillsViewerService GetInstance() => _instance ?? (_instance = new SkillsViewerService());
        
        public List<SkillView> GetAllSkillsFrom(string heroName)
        {
            var heroClass = ClassService.GetClassFrom(heroName);
            
            var skills = SkillService.Skills.ToList()
                .FindAll(s =>
                {
                    var canBeUsed = s.usedBy.Any(u => u.Equals(heroClass.name));
                    var isPassive = s.type.Equals("passive");
                    return canBeUsed && isPassive;
                });
            
            var skillViews = SkillViewerResource.Get()
                .FindAll(fs => skills.Any(sv => sv.name.Equals(fs.name)));

            return skillViews;
        }
    }
}