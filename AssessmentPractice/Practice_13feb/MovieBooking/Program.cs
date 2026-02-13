public class Program
{
    public static void Main()
    {
        //Movie Booking – Seat Allocation
        //Always allocate the lowest available seat.
        // If seats run out, return -1 for remaining requests.
        // Use a sorted structure (example: SortedSet<int> of available seats).

        int n = 10;
        List<int> alreadyBooked = new List<int> {2,5,6,9};
        int requestCount = 5;
        List<int> allocatedSeats = new List<int>();

        SortedSet<int> availableSeats = new SortedSet<int>();

        for(int i = 1; i <= n; i++)
        {
            availableSeats.Add(i);
        }

        foreach(var i in alreadyBooked)
        {
            availableSeats.Remove(i);
        }

        for(int i = 0; i < requestCount; i++)
        {
            if (availableSeats.Count > 0)
            {
                int lowestSeat = availableSeats.Min;
                allocatedSeats.Add(lowestSeat);
                availableSeats.Remove(lowestSeat);
            }
            else
            {
                allocatedSeats.Add(-1);
            }
        }

        foreach(var i in allocatedSeats)
        {
            Console.WriteLine(i);
        }
    }
}