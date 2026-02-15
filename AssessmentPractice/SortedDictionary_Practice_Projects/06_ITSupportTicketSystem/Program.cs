using System;
using Services;
using Domain;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            SupportService service = new SupportService();

            while (true)
            {
                try
                {
                    Console.WriteLine("1. Display Tickets");
                    Console.WriteLine("2. Escalate Ticket");
                    Console.WriteLine("3. Add Ticket");
                    Console.WriteLine("4. Exit");

                    Console.Write("Enter your choice: ");
                    int choice = int.Parse(Console.ReadLine()!);

                    switch (choice)
                    {
                        //Display Tickets
                        case 1:
                            service.DisplayTickets();
                            break;

                        //Escalate Ticket
                        case 2:
                            Console.Write("Ticket Id: ");
                            int id = int.Parse(Console.ReadLine()!);
                            service.EscalateTicket(id);
                            Console.WriteLine("Ticket escalated");
                            break;

                        //Add ticket
                        case 3:
                            Console.Write("Enter (Id Description Severity): ");
                            var splitData = Console.ReadLine()!.Split(" ");

                            service.AddTicket(new SupportTicket{TicketId = int.Parse(splitData[0]), IssueDescription = splitData[1], SeverityLevel = int.Parse(splitData[2])});

                            Console.WriteLine("Ticket added");
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
