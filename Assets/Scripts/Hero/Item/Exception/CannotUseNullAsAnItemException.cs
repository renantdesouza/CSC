using System;

namespace BusinessException
{
    public class CannotUseNullAsAnItemException: Exception
    {
        public CannotUseNullAsAnItemException(): base("Null não pode ser usado como item.")
        {
        }
    }
}