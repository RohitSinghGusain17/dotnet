public class Program
{
    public static void Main()
    {
        int[] sales = [2345,5465,2345,345,345,3456,435,765];
        int high=sales.Max();
        int low=sales.Min();
        double avg=sales.Average();
        Console.WriteLine($"Highest {high}, lowest {low}, average {avg}");
    }
}