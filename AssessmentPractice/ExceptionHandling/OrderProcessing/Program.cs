using System;

public class OrderProcessor
{
    public static void Main()
    {
        int[] orders = { 101, -1, 103 };

        // 1. Process each order
        // 3. Ensure one failure does not stop processing
        for (int i = 0; i < orders.Length; i++)
        {
            try
            {
                if (orders[i] <= 0)
                {
                    // 2. Throw exception for invalid order ID
                    throw new ArgumentException($"{orders[i]} : Invalid order id");
                }
                else
                {
                    Console.WriteLine($"{orders[i]} : Valid");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}