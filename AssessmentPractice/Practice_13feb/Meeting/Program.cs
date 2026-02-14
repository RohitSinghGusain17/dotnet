public class Jewellery
{
    public string? Id{get; set;}
    public string? Type{get; set;}
    public string? Material{get; set;}
    public int Price{get; set;}
}

public class JewelleryUtility
{
    public Dictionary<string, string> GetJewelleryDetails(string id)
    {
        Dictionary<string, string> result = new Dictionary<string, string>();
        foreach(var i in Program.jewelleryDetails)
        {
            if (i.Value.Id == id)
            {
                result[i.Value.Id]=$"{i.Value.Type}_{i.Value.Material}";
            }
        }

        return result;
    }

    public Dictionary<string, Jewellery> UpdateJewelleryPrice(string id, int price)
    {
        Dictionary<string, Jewellery> result = new Dictionary<string, Jewellery>();
        foreach(var i in Program.jewelleryDetails)
        {
            if (i.Value.Id == id)
            {
                i.Value.Price=price;
                result[i.Value.Id]=i.Value;
            }
        }

        return result;
    }
}

public class Program
{
    public static Dictionary<int, Jewellery> jewelleryDetails = new Dictionary<int, Jewellery>();
    public static void Main()
    {
        jewelleryDetails[1]=new Jewellery{Id="1",Material="Gold",Type="Ring", Price=10000};
        jewelleryDetails[2]=new Jewellery{Id="2",Material="Silver",Type="Ring", Price=1000};
        jewelleryDetails[3]=new Jewellery{Id="3",Material="Gold",Type="Necklace", Price=100000};

        bool flag = true;
        while (flag)
        {
            JewelleryUtility jewelleryUtility = new JewelleryUtility();
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("1.Get Jewelley Details");
            Console.WriteLine("2.Update Price");
            Console.WriteLine("3.Exit");
            Console.WriteLine("Enter your choice : ");
            int choice = int.Parse(Console.ReadLine()!);
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter the jewellery id : ");
                    string id = Console.ReadLine()!;
                    var result = jewelleryUtility.GetJewelleryDetails(id);
                    if (result.Count == 0)
                    {
                        Console.WriteLine("Jewellery id not found");
                    }
                    else
                    {
                        foreach(var i in result)
                        {
                            Console.WriteLine($"{i.Key} {i.Value}");
                        }
                    }
                    break;
                case 2:
                    Console.WriteLine("Enter the jewellery id : ");
                    string id1 = Console.ReadLine()!;
                    Console.WriteLine("Enter updated Price : ");
                    int updatedPrice = int.Parse(Console.ReadLine()!);
                    var result1 = jewelleryUtility.UpdateJewelleryPrice(id1,updatedPrice);
                    if (result1.Count == 0)
                    {
                        Console.WriteLine("Jewellery id not found");
                    }
                    else
                    {
                        foreach(var i in result1)
                        {
                            Console.WriteLine($"ID: {i.Key}, Type: {i.Value.Type}, Price: {i.Value.Price}");
                        }
                    }
                    break;
                case 3:
                    flag=false;
                    Console.WriteLine("Thank You");
                    break;
            }
        }
    }
}