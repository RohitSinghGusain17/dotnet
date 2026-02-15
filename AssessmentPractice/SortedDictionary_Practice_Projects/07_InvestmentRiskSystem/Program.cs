using System;
using Services;
using Domain;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            InvestmentService service = new InvestmentService();

            while (true)
            {
                try
                {
                    Console.WriteLine("1. Display");
                    Console.WriteLine("2. Update Risk");
                    Console.WriteLine("3. Add Investment");
                    Console.WriteLine("4. Exit");

                    Console.WriteLine("Enter your choice: ");
                    int choice = int.Parse(Console.ReadLine()!);

                    switch (choice)
                    {
                        //Display INvestments
                        case 1:
                            service.DisplayInvestments();
                            break;

                        //Update investemnt
                        case 2:
                            Console.Write("Id: ");
                            int id = int.Parse(Console.ReadLine()!);
                            Console.Write("New Risk: ");
                            int risk = int.Parse(Console.ReadLine()!);

                            service.UpdateRisk(id, risk);
                            Console.WriteLine("Risk updated");
                            break;

                        //Add investment
                        case 3:
                            Console.Write("Enter (Id Name Risk): ");
                            var splitData = Console.ReadLine()!.Split(" ");
                            service.AddInvestment(new Investment{InvestmentId = int.Parse(splitData[0]), AssetName = splitData[1], RiskRating = int.Parse(splitData[2])});

                            Console.WriteLine("Investment added");
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
