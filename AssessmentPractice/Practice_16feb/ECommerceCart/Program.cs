// Base product class
public abstract class Product
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public double Price { get; set; }
}

// Generic shopping cart
public class ShoppingCart<T> where T : Product
{
    private Dictionary<T, int> _cartItems = new Dictionary<T, int>();
    
    // Add product to cart
    public void AddToCart(T product, int quantity)
    {
        if (_cartItems.ContainsKey(product))
        {
            _cartItems[product]+=quantity;
        }
        else
        {
            _cartItems[product]=quantity;
        }
    }
    
    // Calculate total with discount delegate
    public double CalculateTotal(Func<T, double, double> discountCalculator)
    {
        double total = 0;
        foreach (var item in _cartItems)
        {
            double price = item.Key.Price * item.Value;
            if (discountCalculator != null)
                price = discountCalculator(item.Key, price);
            total += price;
        }
        return total;
    }
    
    // Get top N expensive items using LINQ
    public List<T> GetTopExpensiveItems(int n)
    {
        var result = _cartItems.OrderByDescending(x=>x.Key.Price).Select(x=>x.Key).Take(n).ToList();
        return result;
    }
}

public class Electronics : Product { }
public class Clothing : Product { }


public class Program
{
    public static void Main()
    {

        ShoppingCart<Electronics> cart = new ShoppingCart<Electronics>();

        cart.AddToCart(new Electronics { Id = 1, Name = "Laptop", Price = 999.99 }, 1);
        cart.AddToCart(new Electronics { Id = 2, Name = "Mouse", Price = 29.99 }, 2);

        // Apply 10% discount for items over $100
        double total = cart.CalculateTotal((product, price) => price > 100 ? price * 0.9 : price);

        Console.WriteLine($"Total: ${total:F2}");

        var topItems = cart.GetTopExpensiveItems(1);
        Console.WriteLine(topItems[0].Name); // Should output: Laptop
    }
}