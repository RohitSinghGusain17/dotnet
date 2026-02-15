using System;
using Services;
using Domain;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ViolationService service = new ViolationService();

            while (true)
            {
                try
                {
                    Console.WriteLine("1. Display Violations");
                    Console.WriteLine("2. Pay Fine");
                    Console.WriteLine("3. Add Violation");
                    Console.WriteLine("4. Exit");
                    Console.WriteLine("Enter your choice: ");
                    int choice = int.Parse(Console.ReadLine()!);

                    switch (choice)
                    {
                        //Display Violations
                        case 1:
                            service.DisplayViolations();
                            break;
                        
                        //Pay Fine
                        case 2:
                            Console.Write("Vehicle Number: ");
                            string vehicle = Console.ReadLine()!;
                            Console.Write("Amount: ");
                            int amount = int.Parse(Console.ReadLine()!);
                            service.PayFine(vehicle, amount);
                            Console.WriteLine("Fine updated");
                            break;
                        
                        //Add Violation
                        case 3:
                            Console.Write("Enter (Vehicle Owner Fine): ");
                            var splitData = Console.ReadLine()!.Split(" ");

                            service.AddViolation(new Violation{VehicleNumber = splitData[0], OwnerName = splitData[1], FineAmount = int.Parse(splitData[2])});

                            Console.WriteLine("Violation added");
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
