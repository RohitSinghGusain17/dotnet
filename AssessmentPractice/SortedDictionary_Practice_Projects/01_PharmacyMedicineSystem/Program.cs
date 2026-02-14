using System;
using Domain;
using Services;
using Exceptions;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MedicineUtility medicineUtility = new MedicineUtility();

            while (true)
            {
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Update");
                Console.WriteLine("3. Display");
                Console.WriteLine("4. Exit");

                try{
                    // TODO: Read user choice
                    Console.Write("Enter your choice : ");
                    int choice = int.Parse(Console.ReadLine()!);

                    switch (choice)
                    {
                        case 1:
                            // TODO: Add entity
                            Console.WriteLine("Enter medicine details(MedicineID Name Price ExpiryYear) :");
                            string input = Console.ReadLine()!;
                            string[] splitInput = input.Split(" ");
                            int price = int.Parse(splitInput[2]);
                            int expiryyear = int.Parse(splitInput[3]);

                            if (price <= 0)
                            {
                                throw new InvalidPriceException("Price should be greater than zero");
                            }
                            if (splitInput[3].Length != 4)
                            {
                                throw new InvalidExpiryYearException("Invalid Year");
                            }

                            medicineUtility.AddMedicine(new Medicine { Id = splitInput[0], Name = splitInput[1], Price = price, ExpiryYear = expiryyear });
                            Console.WriteLine("Added");
                            break;

                        case 2:
                            // TODO: Update entity
                            Console.Write("Enter Id : ");
                            string id = Console.ReadLine()!;
                            Console.Write("Enter new price : ");
                            int newPrice = int.Parse(Console.ReadLine()!);

                            medicineUtility.UpdateMedicinePrice(id, newPrice);

                            Console.WriteLine("Price updated");
                            break;

                        case 3:
                            // TODO: Display data
                            medicineUtility.GetAllMedicines();
                            break;

                        case 4:
                            Console.WriteLine("Thank You");
                            return;

                        default:
                            // TODO: Handle invalid choice
                            Console.WriteLine("Invalid Choice");
                            break;
                    }
                }
                catch (InvalidPriceException ex)
                {
                    Console.WriteLine("Price Error: " + ex.Message);
                }
                catch (InvalidExpiryYearException ex)
                {
                    Console.WriteLine("Year Error: " + ex.Message);
                }
                catch (DuplicateMedicineException ex)
                {
                    Console.WriteLine("Duplicate Error: " + ex.Message);
                }
                catch (MedicineNotFoundException ex)
                {
                    Console.WriteLine("Not Found: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unexpected Error: " + ex.Message);
                }
            }
        }
    }
}
