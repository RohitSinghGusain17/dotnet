public class Program
{
    public static void Main()
    {
        //Metro Ticketing – Peak Hour Count
        // Count where ticketType == "Regular".
        // Peak window: 08:00 to 10:00 inclusive.
        // Ignore invalid ticket types.

        Queue<(TimeSpan entryTime, string ticketType)> q = new Queue<(TimeSpan entryTime, string ticketType)>();
        q.Enqueue((new TimeSpan(7, 45, 0), "Regular"));
        q.Enqueue((new TimeSpan(8, 15, 0), "Regular"));
        q.Enqueue((new TimeSpan(9, 30, 0), "VIP"));

        var start = TimeSpan.FromHours(8);
        var end = TimeSpan.FromHours(10);

        int count = q.Count(x => x.ticketType == "Regular" && x.entryTime >= start && x.entryTime <= end);
        Console.WriteLine(count);
    }
}