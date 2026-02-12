using System.Text.RegularExpressions;

public class Program
{
    public static void Main()
    {
        //Match a valid IPv4 address (x.x.x.x where each x is 0–255).
        string pattern = @"^([1-9]?[0-9]|[1][0-9][0-9]|[2][0-4][0-9]|25[0-5])\.([1-9]?[0-9]|[1][0-9][0-9]|[2][0-4][0-9]|25[0-5])\.([1-9]?[0-9]|[1][0-9][0-9]|[2][0-4][0-9]|25[0-5])\.([1-9]?[0-9]|[1][0-9][0-9]|[2][0-4][0-9]|25[0-5])$";
        string input = Console.ReadLine()!;
        if (Regex.IsMatch(input, pattern))
        {
            Console.WriteLine("Valid");
        }
        else
        {
            Console.WriteLine("Invalid");
        }
    }
}