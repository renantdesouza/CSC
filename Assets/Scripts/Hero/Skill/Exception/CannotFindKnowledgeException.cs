namespace BusinessException
{
    public class CannotFindKnowledgeException: BusinessException
    {
        public CannotFindKnowledgeException() : base($"Não é possível encontrar a knowledge.")
        {
        }
    }
}