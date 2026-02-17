using System;
using System.IO.Pipelines;

public class Program
{
    // Custom delegate type (industry common in legacy code-bases)
    public delegate void Notifier(string message);

    public static void Main()
    {
        Notifier pipeline = BuildPipeline();        // Combine multiple methods
        pipeline("Order Created");                  // Expected: prints 3 lines (Email/SMS/Log)
    }

    // ✅ TODO: Students implement only this function
    public static Notifier BuildPipeline()
    {
        // TODO: Create a notifier that calls SendEmail, SendSms, and WriteLog in order
        Notifier pipeline = SendEmail;
        pipeline+=SendSms;
        pipeline+=WriteLog;
        return pipeline;
    }

    private static void SendEmail(string message)
    {
        Console.WriteLine($"Email: {message}");
    }

    private static void SendSms(string message)
    {
        Console.WriteLine($"SMS: {message}");
    }

    private static void WriteLog(string message)
    {
        Console.WriteLine($"Log: {message}");
    }
}