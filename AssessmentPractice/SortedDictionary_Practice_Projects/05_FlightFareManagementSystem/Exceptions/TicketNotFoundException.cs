namespace Exceptions
{
    public class TicketNotFoundException : Exception
    {
        public TicketNotFoundException(string msg) : base(msg) { }
    }
}