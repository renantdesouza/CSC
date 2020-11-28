using System.Collections.Generic;
using Hero.Skill;
using Util;

namespace SkillsViewer
{
    public class SkillViewerResource : Resource<SkillViewContainer>
    {
        private static SkillViewerResource _instance;
        private const string RepositoryPath = "Assets/Resources/Data/Hero/Skill";

        private SkillViewerResource()
        {
        }
        
        public List<SkillView> Get()
        {
            var svc = Get<SkillViewContainer>($"{RepositoryPath}/skill-view.json");
            return svc.skills;
        }

        public static SkillViewerResource GetInstance() => _instance ?? (_instance = new SkillViewerResource());
    }
}