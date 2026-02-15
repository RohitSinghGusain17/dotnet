namespace Exceptions
{
    public class DuplicateTicketException : Exception
    {
        public DuplicateTicketException(string msg) : base(msg) { }
    }
}
