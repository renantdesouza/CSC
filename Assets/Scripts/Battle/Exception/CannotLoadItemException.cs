using System;

namespace BusinessException
{
    public class CannotLoadItemException: Exception
    {
        public CannotLoadItemException(string itemName): base($"Não foi possível carregar o equipamento: {itemName}.")
        {
            
        }
    }
}