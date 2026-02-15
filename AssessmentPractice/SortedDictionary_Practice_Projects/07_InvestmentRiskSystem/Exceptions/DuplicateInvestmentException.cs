namespace Exceptions
{
    public class DuplicateInvestmentException : Exception
    {
        public DuplicateInvestmentException(string message) : base(message) { }
    }
}
