public class Product
{
    public string? ID{get; set;}
    public string? Name{get; set;}
    public double Price{get; set;}

    public Product(string id, string name, double price)
    {
        ID=id;
        Name=name;
        Price=price;
    }
}
public class CurrencyConverter
{
    public double CalculateTotal<T>(T item, int quantity, Func<T, int, double> priceCalculator)
    {
        return priceCalculator(item, quantity);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        CurrencyConverter currencyConverter = new CurrencyConverter();
        Product myproduct = new Product("P346","Book", 34);

        var result = currencyConverter.CalculateTotal(myproduct, 3, (p, q) => (p.Price * q) * 1.15);

        Console.WriteLine(result);
    }
}