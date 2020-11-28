using System;

namespace BusinessException
{
    public class CannotLoadSkillsException: Exception
    {
        public CannotLoadSkillsException(string heroName): base($"Não foi possível carregar as habilidades dos heroi: {heroName}.")
        {
        }
        
        public CannotLoadSkillsException(): base("Não foi possível carregar as habilidades")
        {
        }
    }
}