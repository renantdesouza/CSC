namespace BusinessException
{
    public class CannotUseNullAsSkillException: BusinessException
    {
        public CannotUseNullAsSkillException(): base("Null não pode ser usado como skill.")
        {
        }
    }
}