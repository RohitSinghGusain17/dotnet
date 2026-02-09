interface INotifier
{
    public void Send(string message);
}

public class EmailNotifier : INotifier
{
    public void Send(string message)
    {
        Console.WriteLine($"Email Notification {message}");
    }
}

public class SmsNotifier : INotifier
{
    public void Send(string message)
    {
        Console.WriteLine($"Sms Notification {message}");
    }
}

public class WhatsappNotifier : INotifier
{
    public void Send(string message)
    {
        Console.WriteLine($"whatsapp Notification {message}");
    }
}


public class Program
{
    public static void Main()
    {
        List<INotifier> notify = new List<INotifier>();
        notify.Add(new WhatsappNotifier());
        notify.Add(new SmsNotifier());
        notify.Add(new EmailNotifier());
        string message = "Hello user";
        foreach(var i in notify)
        {
            i.Send(message);
        }
    }
}