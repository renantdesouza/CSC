using System;

namespace BusinessException
{
    public class CannotLoadHeroesException: Exception
    {
        public CannotLoadHeroesException(): base("Não foi possível carregar os herois da batalha.")
        {
            
        }
    }
}