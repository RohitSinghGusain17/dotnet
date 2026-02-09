using System.Text;

public class Items
{
    public string? ItemName{get; set;}
    public int Qty{get; set;}
    public double Price{get; set;}
}
public class Program
{
    public static List<Items> items = new List<Items>();
    public static void Main()
    {
        double total=0;
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine("---------Invoice-----------");
        stringBuilder.AppendLine("Itemname Qty Price");
        for(int i = 0; i < 5; i++)
        {
            Console.Write("Enter item name: ");
            string name = Console.ReadLine()!;
            Console.Write("Enter item quantity: ");
            int qty = int.Parse(Console.ReadLine()!);
            Console.Write("Enter item price: ");
            double price = double.Parse(Console.ReadLine()!);
            total+=qty*price;
            items.Add(new Items{ItemName=name, Price=price, Qty=qty});
            stringBuilder.AppendLine($"{name} {qty} {price}");
        }

        stringBuilder.AppendLine($"Total : {total}");

        Console.WriteLine(stringBuilder.ToString());
    }
}