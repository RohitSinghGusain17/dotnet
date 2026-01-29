public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter Deluxe Room Details:");
        Console.Write("Guest Name:");
        string nameDeluxe = Console.ReadLine()!;
        Console.Write("Rate per Night:");
        double rateDeluxe = double.Parse(Console.ReadLine()!);
        Console.Write("Nights Stayed:");
        int nightsStayedDeluxe = int.Parse(Console.ReadLine()!);
        Console.Write("Joining Year:");
        int joiningYearDeluxe = int.Parse(Console.ReadLine()!);

        Console.WriteLine("Enter Suite Room Details:");
        Console.Write("Guest Name:");
        string nameSuite = Console.ReadLine()!;
        Console.Write("Rate per Night:");
        double rateSuite = double.Parse(Console.ReadLine()!);
        Console.Write("Nights Stayed:");
        int nightsStayedSuite = int.Parse(Console.ReadLine()!);
        Console.Write("Joining Year:");
        int joiningYearSuite = int.Parse(Console.ReadLine()!);

        HotelRoom hotelRoomDeluxe = new HotelRoom("Deluxe",rateDeluxe,nameDeluxe);
        HotelRoom hotelRoomSuite = new HotelRoom("Suite",rateSuite,nameSuite);

        Console.WriteLine("Room Summary:");
        Console.WriteLine($"Deluxe Room: {nameDeluxe}, {rateDeluxe:F1} per night, Membership: {hotelRoomDeluxe.calculateMembershipYears(joiningYearDeluxe)} years");
        Console.WriteLine($"Suite Room: {nameSuite}, {rateSuite:F1} per night, Membership: {hotelRoomSuite.calculateMembershipYears(joiningYearSuite)} years");

        Console.WriteLine("Total Bill:");
        Console.WriteLine($"For {nameDeluxe} (Deluxe): {hotelRoomDeluxe.calculateTotalBill(nightsStayedDeluxe,joiningYearDeluxe):F1}");
        Console.WriteLine($"For {nameSuite} (Suite): {hotelRoomSuite.calculateTotalBill(nightsStayedSuite,joiningYearSuite):F1}");
    }
}