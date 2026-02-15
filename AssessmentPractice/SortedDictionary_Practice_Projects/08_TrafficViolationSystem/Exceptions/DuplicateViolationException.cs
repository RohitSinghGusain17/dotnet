namespace Exceptions
{
    public class DuplicateViolationException : Exception
    {
        public DuplicateViolationException(string message) : base(message) { }
    }
}
