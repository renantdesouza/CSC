using System;

namespace BusinessException
{
    public class CannotFindItemException: Exception
    {
        public CannotFindItemException(string itemName): base($"Não foi possível encontrar o item chamado {itemName}")
        {
        }
    }
}