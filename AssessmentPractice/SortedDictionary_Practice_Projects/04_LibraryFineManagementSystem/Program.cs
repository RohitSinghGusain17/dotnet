using System;
using Services;
using Domain;

class Program
{
    static void Main()
    {
        LibraryService service = new LibraryService();

        while (true)
        {
            try
            {
                Console.WriteLine("1. Display Members");
                Console.WriteLine("2. Pay Fine");
                Console.WriteLine("3. Add Member");
                Console.WriteLine("4. Exit");

                int choice = int.Parse(Console.ReadLine()!);

                switch (choice)
                {
                    //Display members
                    case 1:
                        service.DisplayMembers();
                        break;

                    //Pay fine by id
                    case 2:
                        Console.Write("Member Id: ");
                        int id = int.Parse(Console.ReadLine()!);
                        Console.Write("Amount: ");
                        int amt = int.Parse(Console.ReadLine()!);

                        service.PayFine(id, amt);
                        Console.WriteLine("Fine paid");
                        break;

                    //Add member
                    case 3:
                        Console.Write("Enter (Id Name Fine): ");
                        var splitData = Console.ReadLine()!.Split(" ");
                        service.AddMember(new Member{ MemberId = int.Parse(splitData[0]), Name = splitData[1], FineAmount = int.Parse(splitData[2])});

                        Console.WriteLine("Member added");
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