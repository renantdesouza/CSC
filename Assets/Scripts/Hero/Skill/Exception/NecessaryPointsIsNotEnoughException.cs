namespace BusinessException
{
    public class NecessaryPointsIsNotEnoughException: BusinessException
    {
        public NecessaryPointsIsNotEnoughException() : base("Pontos necessários para adicionar skill não são suficientes.")
        {
        }
    }
}