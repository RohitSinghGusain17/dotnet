using System;
using System.Collections.Generic;
using System.Linq;

// Base product interface
public interface IProduct
{
    int Id { get; }
    string Name { get; }
    decimal Price { get; }
    Category Category { get; }
}

public enum Category { Electronics, Clothing, Books, Groceries }

// 1. Create a generic repository for products
public class ProductRepository<T> where T : class, IProduct
{
    private List<T> _products = new();
    // TODO: Implement method to add product with validation
    public void AddProduct(T product)
    {
        // Rule: Product ID must be unique
        // Rule: Price must be positive
        // Rule: Name cannot be null or empty
        // Add to collection if validation passes
        if (product == null)
            throw new ArgumentNullException(nameof(product));

        if (_products.Any(p => p.Id == product.Id))
            throw new Exception("Product ID must be unique");

        if (product.Price <= 0)
            throw new Exception("Price must be positive");

        if (string.IsNullOrWhiteSpace(product.Name))
            throw new Exception("Name cannot be empty");

        _products.Add(product);
    }

    // TODO: Create method to find products by predicate
    public IEnumerable<T> FindProducts(Func<T, bool> predicate)
        => _products.Where(predicate);

    // TODO: Calculate total inventory value
    public decimal CalculateTotalValue()
        => _products.Sum(p => p.Price);
}

// 2. Specialized electronic product
public class ElectronicProduct : IProduct
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public decimal Price { get; set; }
    public Category Category => Category.Electronics;
    public int WarrantyMonths { get; set; }
    public string Brand { get; set; } = "";
}

// 3. Create a discounted product wrapper
public class DiscountedProduct<T> where T : IProduct
{
    private T _product;
    private decimal _discount;

    public DiscountedProduct(T product, decimal discount)
    {
        // TODO: Initialize with validation
        // Discount must be between 0 and 100
        if (discount < 0 || discount > 100)
            throw new Exception("Discount must be 0–100");

        _product = product ?? throw new ArgumentNullException();
        _discount = discount;
    }

    // TODO: Implement calculated price with discount
    public decimal DiscountedPrice =>
        _product.Price * (1 - _discount / 100);

    public override string ToString() =>
        $"{_product.Name}: {_product.Price} → {DiscountedPrice}";
}

// 4. Inventory manager with constraints
public class InventoryManager
{
    public void ProcessProducts<T>(IEnumerable<T> products)
        where T : IProduct
    {
        // a) Print all product names and prices
        // b) Find the most expensive product
        // c) Group products by category
        // d) Apply 10% discount to Electronics over $500

        Console.WriteLine("All products:");
        foreach (var p in products)
            Console.WriteLine($"{p.Name} - {p.Price}");

        var expensive = products.MaxBy(p => p.Price);
        Console.WriteLine($"\nMost expensive: {expensive?.Name}");

        Console.WriteLine("\nGrouped by category:");
        var groups = products.GroupBy(p => p.Category);
        foreach (var g in groups)
        {
            Console.WriteLine(g.Key);
            foreach (var p in g)
                Console.WriteLine($"  {p.Name}");
        }

        Console.WriteLine("\nDiscounted electronics > 500:");
        var discounted = products
            .Where(p => p.Category == Category.Electronics && p.Price > 500)
            .Select(p => new DiscountedProduct<T>(p, 10));

        foreach (var d in discounted)
            Console.WriteLine(d);
    }

    // TODO: Implement bulk price update with delegate
    public void UpdatePrices<T>(List<T> products,Func<T, decimal> adjuster
    ) where T : IProduct
    {
        foreach (var p in products)
        {
            try
            {
                if (p is ElectronicProduct ep)
                    ep.Price = adjuster(p);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating {p.Name}: {ex.Message}");
            }
        }
    }
}

// 5. TEST SCENARIO: Your tasks:
// a) Implement all TODO methods with proper error handling
// b) Create a sample inventory with at least 5 products
// c) Demonstrate:
//    - Adding products with validation
//    - Finding products by brand (for electronics)
//    - Applying discounts
//    - Calculating total value before/after discount
//    - Handling a mixed collection of different product types

public class Program
{
    public static void Main()
    {
        var repo = new ProductRepository<ElectronicProduct>();

        var items = new List<ElectronicProduct>
        {
            new() { Id=1, Name="Laptop", Price=800, Brand="Dell" },
            new() { Id=2, Name="Phone", Price=1200, Brand="Apple" },
            new() { Id=3, Name="Headphones", Price=150, Brand="Sony" },
            new() { Id=4, Name="Monitor", Price=600, Brand="Samsung" },
            new() { Id=5, Name="Mouse", Price=40, Brand="Logitech" }
        };

        foreach (var p in items)
        {
            repo.AddProduct(p);
        }

        Console.WriteLine("Apple products:");
        foreach (var p in repo.FindProducts(p => p.Brand == "Apple"))
        {
            Console.WriteLine($"{p.Name} - {p.Price}");
        }

        Console.WriteLine($"\nTotal value: {repo.CalculateTotalValue()}");

        var manager = new InventoryManager();
        manager.ProcessProducts(repo.FindProducts(_ => true));

        Console.WriteLine("\nUpdating prices +5%");
        manager.UpdatePrices(items, p => p.Price * 1.05m);

        Console.WriteLine("\nAfter update:");
        foreach (var p in repo.FindProducts(_ => true))
        {
            Console.WriteLine($"{p.Name} - {p.Price}");
        }
    }
}