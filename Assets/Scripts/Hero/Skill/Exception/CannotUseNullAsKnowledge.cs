namespace BusinessException
{
    public class CannotUseNullAsKnowledge: BusinessException
    {
        public CannotUseNullAsKnowledge() : base("Null não pode ser usado como knowledge")
        {
        }
    }
}