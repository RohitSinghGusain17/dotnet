using System;

namespace Exceptions
{
    public class NegativeBalanceException : Exception
    {
        public NegativeBalanceException(string message) : base(message) { }
    }
}
