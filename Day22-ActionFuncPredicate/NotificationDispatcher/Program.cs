public class NotificationDispatcher
{
    public void ProcessTask<T>(T item, Action<T> action)
    {
        action(item);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        NotificationDispatcher dispatcher =new NotificationDispatcher();
        dispatcher.ProcessTask("Ordered", x => Console.WriteLine("Status: "+x));
        dispatcher.ProcessTask("Dispatched", x => Console.WriteLine("Status: "+x));
    }
}