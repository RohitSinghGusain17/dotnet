using System;

namespace Exceptions
{
    public class InvalidSeverityException : Exception
    {
        public InvalidSeverityException(string message) : base(message) { }
    }
}
