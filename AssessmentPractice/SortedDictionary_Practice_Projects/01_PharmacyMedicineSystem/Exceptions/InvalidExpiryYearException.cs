namespace Exceptions
{
    public class InvalidExpiryYearException : Exception
    {
        public InvalidExpiryYearException(string message) : base(message) { }
    }
}
