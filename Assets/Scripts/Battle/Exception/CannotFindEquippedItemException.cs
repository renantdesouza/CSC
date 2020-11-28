using System;

namespace BusinessException
{
    public class CannotFindEquippedItemException: Exception
    {
        public CannotFindEquippedItemException(): base("Item equipado não foi encontrado")
        {
            
        }
    }
}