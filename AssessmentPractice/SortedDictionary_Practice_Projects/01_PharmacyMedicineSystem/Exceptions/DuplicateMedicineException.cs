namespace Exceptions
{
    public class DuplicateMedicineException : Exception
    {
        public DuplicateMedicineException(string message) : base(message) { }
    }
}
