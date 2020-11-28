namespace BusinessException
{
    public class CannotAddSkillWithLessKnowledgeLevelException: BusinessException
    {
        public CannotAddSkillWithLessKnowledgeLevelException(): base("Não é possível adicionar uma skill com nível de aprendizado.")
        {
        }
    }
}