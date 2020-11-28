using System.Collections.Generic;
using System.Linq;
using Battle;
using BusinessException;
using Hero.Status;
using UnityEngine;

namespace Hero.Skill
{
    public class SkillService
    {
        private static SkillService _instance;

        private readonly SkillResource SkillResource;

        private readonly StatusService StatusService;

        public readonly List<Skill> Skills;

        private SkillService()
        {
            SkillResource = SkillResource.GetInstance();
            StatusService = StatusService.GetInstance();
            Skills = Get();
        }

        public static SkillService GetInstance() => _instance ?? (_instance = new SkillService());

        private List<Skill> Get()
        {
            return SkillResource.Get();
        }

        public List<SkillKnowledge> GetSkillsFrom(string heroName)
        {
            return SkillResource.GetSkillsFrom(heroName);
        }

        public Skill GetSkillByName(string name)
        {
            return Skills.Find(skill => skill.name.ToLower().Equals(name.ToLower()));
        }

        private static bool CanBeUsedBy(HeroBattle hero, Skill skill)
        {
            return skill.usedBy.Any(usedBy => usedBy.Equals(hero.Class.name));
        }

        public void AddSkill(HeroBattle hero, string skillName, string knowledgeLevel)
        {
            // Verifica se herói tem experiência disponível para adquirir a skill.
            KnowledgeLevel level = null;

            if (knowledgeLevel == null)
            {
                throw new CannotUseNullAsKnowledge();
            }

            if (skillName == null)
            {
                throw new CannotUseNullAsSkillException();
            }

            if (KnowledgeLevel.Assimilate.Name.Equals(knowledgeLevel.ToLower()))
            {
                level = KnowledgeLevel.Assimilate;
            }
            else if (KnowledgeLevel.Learn.Name.Equals(knowledgeLevel.ToLower()))
            {
                level = KnowledgeLevel.Learn;
            }
            else
            {
                throw new CannotFindKnowledgeException();
            }
            
            if (StatusService.GetPoints(hero.Name) < level.NecessaryPoints)
            {
                throw new NecessaryPointsIsNotEnoughException();
            }

            // Verifica se a skill existe e pode ser usada pela classe do herói.
            var skill = GetSkillByName(skillName);

            if (skill == null)
            {
                throw new CannotFindSkillException(skillName);
            }

            if (!CanBeUsedBy(hero, skill))
            {
                throw new ItemCannotBeUsedByThisClassException();
            }

            // Verifica se o herói já possui a skill
            var skillKnowledge = GetSkillsFrom(hero.Name).FirstOrDefault(sk => sk.skill.Equals(skillName));
            if (skillKnowledge != null)
            {
                if (knowledgeLevel.Equals(skillKnowledge.knowledge))
                {
                    throw new SkillAlreadyLearnedException();
                }

                // não permite assimilar uma skill já aprendida.
                var alreadyLearnedTheSkill = skillKnowledge.knowledge.Equals(KnowledgeLevel.Learn.Name);
                if (alreadyLearnedTheSkill)
                {
                    throw new CannotAddSkillWithLessKnowledgeLevelException();
                }
            }

            // Não permite adicionar a nova skill se não cumprir os requisitos.
            if (skill.requirements != null &&
                hero.Skills.All(s => s.name?.ToLower().Equals(skill.requirements[0]?.ToLower()) == null))
            {
                throw new CannotFindRequiredSkillToAdd(skillName, skill.requirements[0]);
            }

            // Adiciona a skill ao herói.
            var skills = hero.Skills.ToList();
            skills.Add(skill);
            hero.Skills = skills.ToArray();

            StatusService.ConsumeTheNecessaryPoints(hero.Name, level);
            Save(hero, skillName, knowledgeLevel);
        }

        private void Save(HeroBattle hero, string skillName, string skillKnowledge)
        {
            var sks = GetSkillsFrom(hero.Name);
            var sk = new SkillKnowledge()
            {
                skill = skillName,
                knowledge = skillKnowledge
            };

            var skill = sks.Find(s => s.skill.Equals(skillName));

            if (skill == null)
            {
                sks.Add(sk);
            }
            else
            {
                skill.skill = sk.skill;
                skill.knowledge = sk.knowledge;
            }

            SkillResource.Save(hero.Name, new SkillKnowledgeContainer()
            {
                skills = sks
            });
        }
    }
}