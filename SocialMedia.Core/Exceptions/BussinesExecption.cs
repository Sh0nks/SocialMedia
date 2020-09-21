using System;

namespace SocialMedia.Core.Exceptions
{
    public class BussinesExecption: Exception
    {
        public BussinesExecption()
        {
            
        }

        public BussinesExecption(String message): base(message)
        {}
    }
}