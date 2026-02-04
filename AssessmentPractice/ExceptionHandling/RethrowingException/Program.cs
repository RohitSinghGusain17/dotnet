using System;

public class ExceptionRethrow
{
    public static void Main()
    {
        try
        {
            ProcessData();
        }
        catch (Exception ex)
        {
            // Log exception
            Console.WriteLine("Caught in Main:"+ex.Message);
        }
    }

    public static void ProcessData()
    {
        try
        {
            int.Parse("ABC");
        }
        catch (Exception ex)
        {
            // Log exception
            Console.WriteLine("Logging in ProcessData: "+ex.Message);
            // Rethrow while preserving stack trace
            throw;
        }
    }
}