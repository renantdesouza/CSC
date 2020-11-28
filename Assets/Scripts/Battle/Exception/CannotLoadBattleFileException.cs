using System;

namespace BusinessException
{
    public class CannotLoadBattleFileException: Exception
    {
        public CannotLoadBattleFileException(): base($"Não foi possível carregar o arquivo das batalhas.")
        {
            
        }
    }
}