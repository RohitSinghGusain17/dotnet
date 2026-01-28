using System.Data;
using System.Runtime.ConstrainedExecution;
using System.Text;
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter number of cake orders to be added");
        int number = int.Parse(Console.ReadLine()!);
        Console.WriteLine("Enter the cake order details (OrderID:CakeCost)");
        CakeOrder cakeOrder = new CakeOrder();
        for(int i = 0; i < number; i++)
        {
            string order = Console.ReadLine()!;
            string[] orderDetail = order.Split(":");
            cakeOrder.addOrderDetails(orderDetail[0],double.Parse(orderDetail[1]));
        }

        Console.WriteLine("Enter the cost to search the cake orders");
        double cost = double.Parse(Console.ReadLine()!);
        Console.WriteLine("Cake orders above the specified cost");
        var result = cakeOrder.FindOrderAboveSpecifiedCost(cost);
        if (result.Count == 0)
        {
            Console.WriteLine("No cake order found!");
        }
        else
        {
            foreach(var i in result)
            {
                Console.WriteLine($"Order ID: {i.Key}, Cake Cost: {i.Value}");
            }
        }
    }
}