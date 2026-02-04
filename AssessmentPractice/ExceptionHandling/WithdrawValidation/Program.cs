public class BankAccount
{
    public static void Main(string[] args)
    {
        int balance = 10000;
        Console.WriteLine("Enter withdrawal amount:");
        int amount = int.Parse(Console.ReadLine()!);

        try
        {
            // 1. Throw exception if amount <= 0
            if (amount <= 0)
            {
                throw new ArgumentException("Amount should not be less than zero");
            }
            // 2. Throw exception if amount > balance
            else if (amount > balance)
            {
                throw new ArgumentException("Amount should not be greater than balance");
            }
            // 3. Deduct amount if valid
            else
            {
                balance-=amount;
            }
        }
        catch(ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
        // 4. Use finally block to log transaction
        finally
        {
            Console.WriteLine("Transaction completed");
        }
    }
}