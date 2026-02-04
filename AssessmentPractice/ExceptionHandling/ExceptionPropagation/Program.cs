using System;

public class Controller
{
    public static void Main()
    {
        // Call Service method
        try
        {
            Service.Process();
        }
        // Handle exception here
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

public class Service
{
    public static void Process()
    {
        // Call Repository method
        try
        {
            Repository.GetData();
        }
        // Catch, log and rethrow exception
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

public class Repository
{
    public static void GetData()
    {
        // Throw an exception here
        throw new Exception("Exception thrown");
    }
}