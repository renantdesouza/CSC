namespace BusinessException
{
    public class SkillCannotBeUsedByThisClassException: BusinessException
    {
        public SkillCannotBeUsedByThisClassException(): base("Skill não pode ser usado por esta classe.")
        {
        }
    }
}