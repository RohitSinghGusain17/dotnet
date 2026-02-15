using System;
using Services;
using Domain;

class Program
{
    static void Main()
    {
        TicketService service = new TicketService();

        while (true)
        {
            try
            {
                Console.WriteLine("1. Display Tickets");
                Console.WriteLine("2. Update Fare");
                Console.WriteLine("3. Add Ticket");
                Console.WriteLine("4. Exit");

                int choice = int.Parse(Console.ReadLine()!);

                switch (choice)
                {
                    //Display all tickets
                    case 1:
                        service.DisplayTickets();
                        break;

                    //Update fare
                    case 2:
                        Console.Write("Ticket Id: ");
                        int id = int.Parse(Console.ReadLine()!);
                        Console.Write("New Fare: ");
                        int fare = int.Parse(Console.ReadLine()!);

                        service.UpdateFare(id, fare);
                        Console.WriteLine("Fare updated");
                        break;
                    
                    //Add Passenger
                    case 3:
                        Console.Write("Enter (Id Name Fare): ");
                        var splitData = Console.ReadLine()!.Split(" ");

                        service.AddTicket(new Ticket{TicketId = int.Parse(splitData[0]), PassengerName = splitData[1], Fare = int.Parse(splitData[2])});

                        Console.WriteLine("Ticket added");
                        break;
                    
                    //Exit
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Invalid Choice");
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