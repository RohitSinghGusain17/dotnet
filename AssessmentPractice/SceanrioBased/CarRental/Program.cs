public class RentalCar
{
    public string? LicensePlate{get; set;}
    public string? Make{get; set;}
    public string? Model{get; set;}
    public string? CarType{get; set;}
    public bool IsAvailable{get; set;}
    public double DailyRate{get; set;}
}

public class Rental
{
    public int RentalId{get; set;}
    public string? LicensePlate{get; set;}
    public string? CustomerName{get; set;}
    public DateTime StartDate{get; set;}
    public DateTime EndDate{get; set;}
    public double TotalCost{get; set;}
}

public class RentalManager
{
    private int unique = 1;
    public List<RentalCar> Cars = new List<RentalCar>();
    public List<Rental> Rentals = new List<Rental>();

    public void AddCar(string license, string make, string model, string type, double rate)
    {
        Cars.Add(new RentalCar{LicensePlate = license, Make = make, Model = model, CarType = type, IsAvailable = true, DailyRate = rate});
    }

    public bool RentCar(string license, string customer, DateTime start, int days)
    {
        var car = Cars.FirstOrDefault(x => x.LicensePlate == license && x.IsAvailable);
        if (car == null)
        {
            return false;
        }

        DateTime end = start.AddDays(days);
        double cost = car.DailyRate * days;
        Rentals.Add(new Rental{RentalId = unique++, LicensePlate = license, CustomerName = customer, StartDate = start, EndDate = end, TotalCost = cost});

        car.IsAvailable = false;
        return true;
    }

    public Dictionary<string, List<RentalCar>> GroupCarsByType()
    {
        Dictionary<string, List<RentalCar>> result =new Dictionary<string, List<RentalCar>>();
        var groups = Cars.Where(x => x.IsAvailable).GroupBy(x => x.CarType);

        foreach (var g in groups)
        {
            result[g.Key!] = g.ToList();
        }

        return result;
    }

    public List<Rental> GetActiveRentals()
    {
        DateTime now = DateTime.Now;

        return Rentals.Where(x => x.StartDate <= now && x.EndDate >= now).ToList();
    }

    public double CalculateTotalRentalRevenue()
    {
        return Rentals.Sum(x => x.TotalCost);
    }
}


public class Program
{
    public static void Main()
    {
        RentalManager manager = new RentalManager();

        manager.AddCar("DL01A1234", "Toyota", "Camry", "Sedan", 3000);
        manager.AddCar("DL02B5678", "Honda", "CRV", "SUV", 4500);

        // Rent a car
        Console.WriteLine(manager.RentCar("UK01A2005", "Rohit", DateTime.Now, 3));

        // Active rentals
        Console.WriteLine("\nActive Rentals:");
        foreach (var r in manager.GetActiveRentals())
        {
            Console.WriteLine($"{r.CustomerName} - {r.LicensePlate}");
        }

        // Revenue
        Console.WriteLine("\nTotal Revenue: " + manager.CalculateTotalRentalRevenue());

        // Group available cars
        var groups = manager.GroupCarsByType();
        Console.WriteLine("\nAvailable Cars by Type:");

        foreach (var g in groups)
        {
            Console.WriteLine(g.Key + ":");
            foreach (var c in g.Value)
            {
                Console.WriteLine($"  {c.Make} {c.Model}");
            }
        }
    }
}