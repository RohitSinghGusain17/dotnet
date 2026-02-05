public class Program
{
    public static void Main(string[] args)
    {
        ThreaterManager manager = new ThreaterManager();

        // Add Screenings
        manager.AddScreening("Inception", new DateTime(2026, 2, 2, 10, 0, 0), "Screen 1", 100, 250);
        manager.AddScreening("Inception", new DateTime(2026, 2, 2, 14, 0, 0), "Screen 2", 80, 300);
        manager.AddScreening("Interstellar", new DateTime(2026, 2, 2, 12, 0, 0), "Screen 3", 120, 200);

        // Book Tickets
        Console.WriteLine("Booking Tickets:");
        Console.WriteLine(manager.BookTickets("Inception", new DateTime(2026, 2, 2, 10, 0, 0), 5));   // true
        Console.WriteLine(manager.BookTickets("Interstellar", new DateTime(2026, 2, 2, 12, 0, 0), 50)); // true
        Console.WriteLine(manager.BookTickets("Inception", new DateTime(2026, 2, 2, 10, 0, 0), 200)); // false

        // Group by Movie
        Console.WriteLine("\nGrouped Screenings:");
        var grouped = manager.GroupScreeningsByMovie();
        foreach (var item in grouped)
        {
            Console.WriteLine($"Movie: {item.Key}");
            foreach (var show in item.Value)
            {
                Console.WriteLine($"  Time: {show.ShowTime}, Screen: {show.ScreenNumber}");
            }
        }

        // Get Available Screenings
        Console.WriteLine("\nAvailable Screenings (min 30 seats):");
        var available = manager.GetAvailableScreenings(30);
        foreach (var show in available)
        {
            Console.WriteLine($"{show.MovieTitle} at {show.ShowTime} | Available Seats: {show.TotalSeats - show.BookedSeats}");
        }

        // Total Revenue
        Console.WriteLine("\nTotal Revenue:");
        Console.WriteLine(manager.CalculateTotalRevenue());
        Console.ReadLine();
    }
}