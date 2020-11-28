using System;

namespace BusinessException
{
    public class BusinessException: Exception
    {
        public BusinessException(string message): base(message) 
        {
        }
    }
}