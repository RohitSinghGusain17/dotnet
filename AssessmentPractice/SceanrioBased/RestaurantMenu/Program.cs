public class MenuItem
{
    public string? ItemName{get; set;}
    public string? Category{get; set;}
    public double Price{get; set;}
    public bool IsVegetatian;
}

public class MenuManager
{
    public List<MenuItem> Menu = new List<MenuItem>();
    public void AddMenuItem(string name, string category, double price, bool IsVeg)
    {
        Menu.Add(new MenuItem{ItemName=name, Category=category, Price=price, IsVegetatian=IsVeg});
    }

    public Dictionary<string, List<MenuItem>> GroupItemsByCategory()
    {
        return Menu.GroupBy(x=>x.Category).ToDictionary(g => g.Key!, g => g.ToList());
    }

    public List<MenuItem> GetVegetarianItems()
    {
        return Menu.Where(x => x.IsVegetatian).ToList();
    }

    public double CalculateAveragePriceByCategory(string category)
    {
        return Menu.Where(x => x.Category == category).Average(x => x.Price);
    }
}


public class Program
{
    public static void Main()
    {
        MenuManager manager = new MenuManager();

        manager.AddMenuItem("Paneer Curry", "Main Course", 250, true);
        manager.AddMenuItem("Chicken Curry", "Main Course", 350, false);
        manager.AddMenuItem("Salad", "Starter", 120, true);
        manager.AddMenuItem("Ice Cream", "Dessert", 150, true);

        // Vegetarian items
        Console.WriteLine("Vegetarian Items:");
        foreach (var item in manager.GetVegetarianItems())
        {
            Console.WriteLine($"{item.ItemName} - {item.Price}");
        }

        // Average price
        double avg = manager.CalculateAveragePriceByCategory("Main Course");
        Console.WriteLine($"\nAverage price (Main Course): {avg}");
    }
}