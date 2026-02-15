using System;

namespace Exceptions
{
    public class InvalidSeverityLevelException : Exception
    {
        public InvalidSeverityLevelException(string message) : base(message) { }
    }
}
