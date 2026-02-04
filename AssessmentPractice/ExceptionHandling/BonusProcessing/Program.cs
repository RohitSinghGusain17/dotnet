using System;

public class BonusCalculator
{
    public static void Main()
    {
        int[] salaries = { 5000, 0, 7000 };
        Console.WriteLine("Enter bonus : ");
        int bonus = int.Parse(Console.ReadLine()!);

        // 1. Loop through salaries
        for (int i = 0; i < salaries.Length; i++)
        {
            try
            {
                // 2. Divide bonus by salary
                double result = bonus/salaries[i];
                Console.WriteLine($"{bonus}/{salaries[i]} Successfully");
            }
            // 3. Handle DivideByZeroException
            catch (DivideByZeroException ex)
            {
                Console.Write($"{bonus}/{salaries[i]} : ");
                Console.WriteLine(ex.Message);
            }
            // 4. Continue processing remaining employees
        }
        }
    }