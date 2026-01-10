public class AppCustomException : Exception
{
    public override string Message => HandleBase(base.Message);

    private string HandleBase(string message)
    {
        Console.WriteLine(message);
        return "Internal Exception Occured";
    }
}