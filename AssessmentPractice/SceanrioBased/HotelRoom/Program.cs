public class Room
{
    public int RoomNumber{get; set;}
    public string? RoomType{get; set;}
    public double PricePerNight{get; set;}
    public bool IsAvailable{get; set;}
}

public class HotelManager
{
    public List<Room> RoomList = new List<Room>();
    public void AddRoom(int roomNumber, string type, double price)
    {
        RoomList.Add(new Room{RoomNumber=roomNumber, RoomType=type, PricePerNight=price, IsAvailable=true});
    }
    
    public Dictionary<string, List<Room>> GroupRoomsByType()
    {
        Dictionary<string, List<Room>> result = new Dictionary<string, List<Room>>();
        var ex = RoomList.GroupBy(x=>x.RoomType);
        foreach(var i in ex)
        {
            result[i.Key!]=i.ToList();
        }

        return result;
    }

    public bool BookRoom(int roomNumber, int nights)
    {
        var room = RoomList.FirstOrDefault(x=>x.RoomNumber==roomNumber && x.IsAvailable);
        if (room == null)
        {
            return false;
        }
        room.IsAvailable=false;
        double totalCost = room.PricePerNight * nights;
        Console.WriteLine($"Room booked, Total cost: {totalCost}");

        return true;
    }

    public List<Room> GetAvailableRoomsByPriceRange(double min, double max)
    {
        return RoomList.Where(x => x.IsAvailable && x.PricePerNight >= min && x.PricePerNight <= max).ToList();
    }
}


public class Program
{
    public static void Main()
    {
        HotelManager manager = new HotelManager();

        manager.AddRoom(101, "Single", 2000);
        manager.AddRoom(102, "Double", 3500);
        manager.AddRoom(103, "Single", 2200);
        manager.AddRoom(104, "Suite", 6000);

        // Book a room
        bool booked = manager.BookRoom(101, 2);
        Console.WriteLine("Booking status: " + booked);

        // Show available rooms in price range
        var rooms = manager.GetAvailableRoomsByPriceRange(2000, 4000);

        Console.WriteLine("Available rooms in range:");
        foreach (var r in rooms)
        {
            Console.WriteLine($"{r.RoomNumber} - {r.RoomType} - {r.PricePerNight}");
        }
    }
}