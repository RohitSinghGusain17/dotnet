public class Bike
{
    public string? Model{get; set;}
    public string? Brand{get; set;}
    public int PricePerDay{get; set;}
}

public class BikeUtility
{
    public void AddBikeDetails(string model, string brand, int pricePerDay)
    {
        Program.bikeDetails[Program.unique++]=new Bike{Model=model, Brand=brand, PricePerDay=pricePerDay};
    }

    public SortedDictionary<string, List<Bike>> GroupBikesByBrand()
    {
        SortedDictionary<string, List<Bike>> group = new SortedDictionary<string, List<Bike>>();
        
        var result = Program.bikeDetails.GroupBy(x=>x.Value.Brand).ToList();
        foreach(var i in result)
        {
            group[i.Key!]=i.Select(x=>x.Value).ToList();
        }

        return group;
    }

}
public class Program
{
    public static int unique = 0;
    public static SortedDictionary<int, Bike> bikeDetails = new SortedDictionary<int, Bike>();
    public static void Main(string[] args)
    {
        bool flag = true;
        while (flag)
        {
            Console.WriteLine("Bike Rental:");
            Console.WriteLine("1. Add Bike Details");
            Console.WriteLine("2. Group bike by brand");
            Console.WriteLine("3. Exit");

            Console.WriteLine("Enter yout choice: ");
            int choice = int.Parse(Console.ReadLine()!);
            BikeUtility bikeUtility = new BikeUtility();
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter the model:");
                    string model = Console.ReadLine()!;
                    Console.WriteLine("Enter the brand");
                    string brand = Console.ReadLine()!;
                    Console.WriteLine("Enter the price per day");
                    int price = int.Parse(Console.ReadLine()!);
                    bikeUtility.AddBikeDetails(model, brand, price);
                    Console.WriteLine("Bike Added Successfully");
                    break;
                case 2:
                    var result = bikeUtility.GroupBikesByBrand();
                    foreach(var i in result)
                    {
                        Console.WriteLine(i.Key);
                        foreach(var j in i.Value)
                        {
                            Console.WriteLine(j.Model);
                        }
                        Console.WriteLine("-----------------");
                    }
                    break;
                case 3:
                    flag=false;
                    break;
            }
        }
    }
}