public class Product
{
    public string? ID{get; set;}
    public string? Name{get; set;}
    public double Price{get; set;}
}
public class DataFilter
{
    public List<T> FilterData<T>(List<T> list, Predicate<T> pre)
    {
        var result = list.Where(x=>pre(x)).ToList();
        return result;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        DataFilter dataFilter = new DataFilter();
        List<Product> products = new List<Product>();
        products.Add(new Product{ID="P346",Name="Book",Price=34});   
        products.Add(new Product{ID="P343",Name="Pencil",Price=33});   
        products.Add(new Product{ID="P344",Name="Pen",Price=39});

        var data = dataFilter.FilterData(products, x=>x.Price>35); 
        foreach(var i in data)
        {
            Console.WriteLine($"{i.ID} {i.Name} {i.Price}");
        }
    }
}