using System;
using Services;
using Domain;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            AccountService service = new AccountService();
            service.AddSampleData();

            while (true)
            {
                try
                {
                    Console.WriteLine("1. Deposit");
                    Console.WriteLine("2. Withdraw");
                    Console.WriteLine("3. Display Accounts");
                    Console.WriteLine("4. Exit");

                    Console.Write("Enter choice: ");
                    int choice = int.Parse(Console.ReadLine()!);

                    switch (choice)
                    {
                        //Deposit Amount
                        case 1:
                            Console.Write("Account Number: ");
                            int depAcc = int.Parse(Console.ReadLine()!);
                            Console.Write("Amount: ");
                            decimal depAmt = decimal.Parse(Console.ReadLine()!);
                            service.Deposit(depAcc, depAmt);
                            Console.WriteLine("Deposit successful");
                            break;

                        //Withdraw Amount
                        case 2:
                            Console.Write("Account Number: ");
                            int witAcc = int.Parse(Console.ReadLine()!);
                            Console.Write("Amount: ");
                            decimal witAmt = decimal.Parse(Console.ReadLine()!);
                            service.Withdraw(witAcc, witAmt);
                            Console.WriteLine("Withdrawal successful");
                            break;

                        //Display Amount
                        case 3:
                            service.DisplayAccounts();
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