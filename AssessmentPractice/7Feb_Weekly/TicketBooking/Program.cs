using NUnit.Framework;
using System.Collections.Generic;

public class Booking
{
    public static Dictionary<int, bool> Seat = new Dictionary<int, bool>();
    private static readonly object SeatLock = new object();
    public bool BookSeat(int seatNo, string userId)
    { 
        lock (SeatLock)
        {
            if (Seat.ContainsKey(seatNo) && Seat[seatNo]==true)
            {
                Console.WriteLine($"{seatNo} Seat Already booked");
                return false;
            }

            Seat[seatNo]=true;
            Console.WriteLine($"{seatNo} Seat booked. Thank you");
            return true;
        }
    }
}

[TestFixture]
public class TestBooking
{
    [Test]
    public void Test_BookSeat()
    {
        Booking booking = new Booking();
        bool test1 = booking.BookSeat(1,"user1");
        bool test2 = booking.BookSeat(1,"user2");
        bool test3 = booking.BookSeat(2,"user3");
        bool test4 = booking.BookSeat(3,"user2");

        Assert.That(test1,Is.EqualTo(true));
        Assert.That(test2,Is.EqualTo(false));
        Assert.That(test3,Is.EqualTo(true));
        Assert.That(test4,Is.EqualTo(true));
    }
}