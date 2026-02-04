using System;

public class InputHandler
{
    public static void Main()
    {
        // 3. Keep asking until valid number is entered
        while (true)
        {
            try
            {
                // 1. Read input from user
                var input = int.Parse(Console.ReadLine()!);
                if (input is int)
                {
                    break;
                }
            }
            // 2. Handle invalid numeric input
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}