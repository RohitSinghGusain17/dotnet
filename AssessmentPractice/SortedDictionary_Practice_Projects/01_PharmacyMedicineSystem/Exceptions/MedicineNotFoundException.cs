namespace Exceptions
{
    public class MedicineNotFoundException : Exception
    {
        public MedicineNotFoundException(string message) : base(message) { }
    }
}
