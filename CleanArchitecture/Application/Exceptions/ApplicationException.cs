using System;

namespace Application.Exceptions
{
    public class ApplicationException : Exception
    {
        public ApplicationException(string businessMessage) : base(businessMessage)
        {
        }

        public ApplicationException(string businessMessage, Exception innerException) : base(businessMessage, innerException)
        {
        }
    }
}