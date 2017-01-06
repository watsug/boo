﻿#if DNXCORE50
namespace System
{
    public class ApplicationException : Exception
    {
        public ApplicationException(string message) : base(message)
        {
        }
        public ApplicationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
#endif