namespace BusinessException
{
    public class SkillAlreadyLearnedException: BusinessException
    {
        public SkillAlreadyLearnedException(): base("Skill já está registrada como aprendida.")
        {
        }
    }
}