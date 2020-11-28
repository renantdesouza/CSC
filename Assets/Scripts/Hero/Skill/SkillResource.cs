using System.Collections.Generic;
using Util;

namespace Hero.Skill
{
    public class SkillResource: Resource<SkillContainer>
    {
        private static SkillResource _skillResource;
        private const string RepositoryPath = "Assets/Resources/Data/Hero/Skill";
        
        private SkillResource()
        {
        }

        public static SkillResource GetInstance() => _skillResource ?? (_skillResource = new SkillResource());

        public List<Skill> Get()
        {
            var skillContainer = Get<SkillContainer>($"{RepositoryPath}/skill.json");
            return skillContainer.skills;
        }
        
        public List<SkillKnowledge> GetSkillsFrom(string heroName)
        {
            var skillKnowledgeContainer = Get<SkillKnowledgeContainer>($"{RepositoryPath}/{heroName.ToLower()}.json");
            return skillKnowledgeContainer.skills;
        }
        
        public void Save(string heroName, SkillKnowledgeContainer data)
        {
            base.Save($"{RepositoryPath}/{heroName.ToLower()}.json", data);
        }
    }
}