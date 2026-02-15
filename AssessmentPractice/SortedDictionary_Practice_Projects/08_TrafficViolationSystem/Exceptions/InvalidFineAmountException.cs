using System;

namespace Exceptions
{
    public class InvalidFineAmountException : Exception
    {
        public InvalidFineAmountException(string message) : base(message) { }
    }
}
