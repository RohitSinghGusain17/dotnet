public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the number of entries");
        int number = int.Parse(Console.ReadLine()!);
        EntryUtility entryUtility = new EntryUtility();

        for(int i = 1; i <= number; i++)
        {
            try
            {
                Console.WriteLine($"Enter entry {i} details");
                string entry = Console.ReadLine()!;
                string[] entryDetails = entry.Split(":");
                var result1 = entryUtility.ValidateEmployeeID(entryDetails[0]);
                var result2 = entryUtility.validateDuration(int.Parse(entryDetails[2]));
            
                if(result1 && result2)
                {
                    Console.WriteLine("Valid entry details");
                }
            }
            catch(InvalidEntryException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}