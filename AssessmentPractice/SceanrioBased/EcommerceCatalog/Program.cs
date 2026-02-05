public class Product
{
    public string? ProductCode { get; set; }
    public string? ProductName { get; set; }
    public string? Category { get; set; }
    public double Price { get; set; }
    public int StockQuantity { get; set; }
}

public class InventoryManager
{
    private int counter = 1;
    public List<Product> Products = new List<Product>();
    public void AddProduct(string name, string category, double price, int stock)
    {
        string code = "P" + counter.ToString("D3");
        Products.Add(new Product{ProductCode = code, ProductName = name, Category = category, Price = price, StockQuantity = stock});
        counter++;
    }

    public SortedDictionary<string, List<Product>> GroupProductsByCategory()
    {
        SortedDictionary<string, List<Product>> result = new SortedDictionary<string, List<Product>>();
        var product = Products.GroupBy(p => p.Category);

        foreach(var i in product)
        {
            result[i.Key!]=i.ToList();
        }

        return result;
    }

    public bool UpdateStock(string productCode, int quantity)
    {
        var product = Products.FirstOrDefault(p => p.ProductCode == productCode);

        if (product == null || product.StockQuantity < quantity)
        {
            return false;
        }

        product.StockQuantity -= quantity;
        return true;
    }

    public List<Product> GetProductsBelowPrice(double maxPrice)
    {
        return Products.Where(p => p.Price < maxPrice).ToList();
    }

    public Dictionary<string, int> GetCategoryStockSummary()
    {
        return Products.GroupBy(p => p.Category).ToDictionary(g => g.Key!,g => g.Sum(p => p.StockQuantity));
    }
}


public class Program
{
    public static void Main()
    {
        InventoryManager manager = new InventoryManager();

        manager.AddProduct("Laptop", "Electronics", 60000, 10);
        manager.AddProduct("T-Shirt", "Clothing", 800, 50);
        manager.AddProduct("Book", "Books", 500, 30);
        manager.AddProduct("Phone", "Electronics", 25000, 15);

        // Update stock
        Console.WriteLine(manager.UpdateStock("P001", 2));

        // Products below price
        var cheap = manager.GetProductsBelowPrice(1000);
        Console.WriteLine("\nProducts below 1000:");
        foreach (var p in cheap)
        {
            Console.WriteLine($"{p.ProductName} - {p.Price}");
        }
        // Category summary
        var summary = manager.GetCategoryStockSummary();
        Console.WriteLine("\nStock Summary:");
        foreach (var s in summary)
        {
            Console.WriteLine($"{s.Key}: {s.Value}");
        }
    }
}