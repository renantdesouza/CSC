namespace BusinessException
{
    public class CannotFindSkillException: BusinessException
    {
        public CannotFindSkillException(string skillName): base($"Não foi possível encontrar a skill chamada {skillName}")
        {
        }
    }
}