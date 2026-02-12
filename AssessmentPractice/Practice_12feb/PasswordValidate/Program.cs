using System.Text.RegularExpressions;

public class Program
{
    public static void Main()
    {
        //Match a password that is at least 8 characters and includes at least one uppercase, one lowercase, and one digit. (No special-char requirement.)
        string pattern = @"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z]).{8,}$";
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