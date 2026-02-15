using System;

namespace Exceptions
{
    public class InvalidOrderAmountException : Exception
    {
        public InvalidOrderAmountException(string message) : base(message) { }
    }
}
