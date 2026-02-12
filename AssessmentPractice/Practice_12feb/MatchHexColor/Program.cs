using System.Text.RegularExpressions;

public class Program
{
    public static void Main()
    {
        // Match a hex color code: # followed by either 3 or 6 hexadecimal digits (case-insensitive).
        string pattern = @"^#([0-9A-F]{3}|[0-9A-F]{6})$";
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