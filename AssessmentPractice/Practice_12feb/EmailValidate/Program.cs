using System.Text.RegularExpressions;

public class Program
{
    public static void Main()
    {
        string pattern = @"^[a-zA-Z0-9.]+@[a-zA-Z]+.[a-zA-Z]+$";
        Console.WriteLine("Enter email : ");
        string str  = Console.ReadLine()!.ToLower();

        if (Regex.IsMatch(str, pattern))
        {
            Console.WriteLine("Valid");
        }
        else
        {
            Console.WriteLine("Invalid");
        }
    }
}