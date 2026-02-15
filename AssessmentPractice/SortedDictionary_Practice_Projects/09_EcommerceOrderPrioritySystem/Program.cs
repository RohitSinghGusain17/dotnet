using System;
using System.Diagnostics;
using Services;
using Domain;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderService service = new OrderService();

            while (true)
            {
                try
                {
                    Console.WriteLine("1. Display Orders");
                    Console.WriteLine("2. Update Order");
                    Console.WriteLine("3. Add Order");
                    Console.WriteLine("4. Exit");

                    Console.WriteLine("Enter your choice");
                    int choice = int.Parse(Console.ReadLine()!);

                    switch (choice)
                    {
                        //Display orders
                        case 1:
                            service.DisplayOrders();
                            break;

                        //Update order amount
                        case 2:
                            Console.Write("Order Id: ");
                            int id = int.Parse(Console.ReadLine()!);
                            Console.Write("New Amount: ");
                            int amount = int.Parse(Console.ReadLine()!);

                            service.UpdateOrder(id, amount);
                            Console.WriteLine("Order updated");
                            break;

                        //Add order
                        case 3:
                            Console.Write("Enter (Id Name Amount): ");
                            var splitData = Console.ReadLine()!.Split(" ");

                            service.AddOrder(new Order{OrderId = int.Parse(splitData[0]), CustomerName = splitData[1], OrderAmount = int.Parse(splitData[2])});

                            Console.WriteLine("Order added");
                            break;

                        //Exit
                        case 4:
                            Console.WriteLine("Thank you");
                            return;

                        default:
                            Console.WriteLine("Invalid choice");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}
