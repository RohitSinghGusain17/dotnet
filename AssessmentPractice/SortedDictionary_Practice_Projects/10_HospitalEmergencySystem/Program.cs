using System;
using Services;
using Domain;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            HospitalService service = new HospitalService();

            while (true)
            {
                try
                {
                    Console.WriteLine("1. Display Patients");
                    Console.WriteLine("2. Update Severity");
                    Console.WriteLine("3. Add Patient");
                    Console.WriteLine("4. Exit");
                    Console.WriteLine("Enter your choice: ");
                    int choice = int.Parse(Console.ReadLine()!);

                    switch (choice)
                    {
                        //Display Patients
                        case 1:
                            service.DisplayPatients();
                            break;

                        //Update Severity
                        case 2:
                            Console.Write("Patient Id: ");
                            int id = int.Parse(Console.ReadLine()!);
                            Console.Write("New Severity: ");
                            int severity = int.Parse(Console.ReadLine()!);

                            service.UpdateSeverity(id, severity);
                            Console.WriteLine("Severity updated");
                            break;

                        //Add Patient
                        case 3:
                            Console.Write("Enter(Id Name Severity): ");
                            var splitData = Console.ReadLine()!.Split(" ");

                            service.AddPatient(new Patient{PatientId = int.Parse(splitData[0]), Name = splitData[1], SeverityLevel = int.Parse(splitData[2])});

                            Console.WriteLine("Patient added");
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
