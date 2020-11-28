namespace BusinessException
{
    public class CannotFindRequiredSkillToAdd: BusinessException
    {
        public CannotFindRequiredSkillToAdd(string skillName, string requirement) : base($"Não é possível adicionar a skill {skillName}, pois, não foi encontrado a skill {requirement} que é pré requisito.")
        {
        }
    }
}