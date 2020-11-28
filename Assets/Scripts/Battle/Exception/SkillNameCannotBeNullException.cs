using System;

namespace BusinessException
{
    public class SkillNameCannotBeNullException: Exception
    {
        public SkillNameCannotBeNullException(): base("Nome da habilidade não pode ser nulo.")
        {
        }
    }
}