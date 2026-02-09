public class Program
{
    public static void Main()
    {
        string input = Console.ReadLine()!;
        input = input.Trim();
        input = input.ToLower();
        if (input.Contains("gmail.com"))
        {
            input = input.Replace("gmail.com","company.com");
        }
        Console.WriteLine(input);
    }
}