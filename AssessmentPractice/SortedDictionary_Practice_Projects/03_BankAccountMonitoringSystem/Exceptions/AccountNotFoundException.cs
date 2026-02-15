using System;

namespace Exceptions
{
    public class AccountNotFoundException : Exception
    {
        public AccountNotFoundException(string message) : base(message) { }
    }
}
