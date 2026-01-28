using System.Text;
using System.Text.RegularExpressions;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the username");
        string username = Console.ReadLine()!;
        string pattern = @"^[A-Z](4)@10[1-9]|11[0-5]$";

        if (!Regex.IsMatch(username, pattern))
        {
            Console.WriteLine(username+" is an invalid username");
        }
        else
        {
            string result ="TECH_";
            string firstfour=username.Substring(0,4).ToLower();
            string lastTwo = username.Substring(username.Length-2);
            int sum = 0;
            foreach(char c in firstfour)
            {
                sum+=(int)c;
            }
            result+=sum.ToString();
            result+=lastTwo.ToString();

            Console.WriteLine("Password: "+result);
        }
    }
}