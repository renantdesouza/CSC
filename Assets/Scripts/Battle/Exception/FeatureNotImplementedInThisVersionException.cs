using System;

namespace BusinessException
{
    public class FeatureNotImplementedInThisVersionException: Exception
    {
        public FeatureNotImplementedInThisVersionException() : base("Funcionalidade não implementada nessa versão.")
        {
            
        }
    }
}