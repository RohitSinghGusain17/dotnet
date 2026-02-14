using System;
using Services;
using Domain;

class Program
{
    static void Main()
    {
        StudentUtility util = new StudentUtility();

        while (true)
        {
            try
            {
                Console.WriteLine("\n1 Display Ranking");
                Console.WriteLine("2 Update GPA");
                Console.WriteLine("3 Add Student");
                Console.WriteLine("4 Exit");

                // TODO: Read user choice
                Console.Write("Enter choice: ");
                int choice = int.Parse(Console.ReadLine()!);

                switch (choice)
                {
                    case 1:
                        // TODO: Display Data
                        util.DisplayRanking();
                        break;

                    case 2:
                        // TODO: Update entity
                        Console.Write("Enter Id: ");
                        string id = Console.ReadLine()!;

                        Console.Write("Enter new GPA: ");
                        double gpa = double.Parse(Console.ReadLine()!);

                        util.UpdateGPA(id, gpa);
                        Console.WriteLine("GPA updated");
                        break;

                    case 3:
                        // TODO: Add Entity
                        Console.Write("Enter details (Id Name GPA) : ");
                        string[] splitData = Console.ReadLine()!.Split(" ");

                        util.AddStudent(new Student{Id = splitData[0], Name = splitData[1], GPA = double.Parse(splitData[2])});

                        Console.WriteLine("Student added");
                        break;

                    case 4:
                        Console.WriteLine("Thank you");
                        return;

                    default:
                        // TODO: Handle invalid choice
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