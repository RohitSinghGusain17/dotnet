public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter number of details to be added");
        int number = int.Parse(Console.ReadLine()!);
        Console.WriteLine("Enter the details (Apartment number: Rent)");
        Apartment apartment = new Apartment();
        for(int i = 0; i < number; i++)
        {
            string ap = Console.ReadLine()!;
            string[] apartmentDetail = ap.Split(":");
            apartment.addApartmentDetails(apartmentDetail[0],double.Parse(apartmentDetail[1]));
        }

        Console.WriteLine("Enter the range to filter the details");
        double minimum = double.Parse(Console.ReadLine()!);
        double maximum = double.Parse(Console.ReadLine()!);
        var result = apartment.findTotalRentOfApartmetsInTheGivenRange(minimum,maximum);
        Console.WriteLine($"Total Rent in the range {minimum} to {maximum} USD: {result}");
        
    }
}