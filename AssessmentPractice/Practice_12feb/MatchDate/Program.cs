using System.Text.RegularExpressions;

public class Program
{
    public static void Main()
    {
        //Match a date in YYYY-MM-DD format (year = 4 digits; month 01–12; day 01–31 — no per-month validation required).
        string pattern = @"^([0-9]{4})-(0[1-9]|1[0-2])-(0[1-9]|1[0-9]|2[0-9]|3[0-1])$";
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