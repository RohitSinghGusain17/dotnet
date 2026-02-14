using System;

namespace Exceptions
{
    public class InvalidGPAException : Exception
    {
        public InvalidGPAException(string message) : base(message) { }
    }
}
