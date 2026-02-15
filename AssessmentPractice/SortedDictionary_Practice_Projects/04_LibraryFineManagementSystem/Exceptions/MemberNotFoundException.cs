namespace Exceptions
{
    public class MemberNotFoundException : Exception
    {
        public MemberNotFoundException(string msg) : base(msg) { }
    }
}