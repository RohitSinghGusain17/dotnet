using System;

namespace Exceptions
{
    public class InvalidFareException : Exception
    {
        public InvalidFareException(string msg) : base(msg) { }
    }
}
