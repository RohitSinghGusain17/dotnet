using System.Text.RegularExpressions;

public class Program
{
    public static void Main()
    {
        //Match 24-hour time in HH:MM format (00:00 to 23:59).
        string pattern = @"^[0-1][0-9]|2[0-3]:[0-5][0-9]$";
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