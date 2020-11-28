using System;

namespace BusinessException
{
    public class ItemCannotBeUsedByThisClassException: Exception
    {
        public ItemCannotBeUsedByThisClassException(): base("Item não pode ser usado por esta classe.")
        {
        }
    }
}