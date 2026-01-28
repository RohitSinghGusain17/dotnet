using System.Diagnostics;
using System.Text.RegularExpressions;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the sentence");
        string input = Console.ReadLine()!;
        string pattern = @"^[A-Za-z]$";
        if (!Regex.IsMatch(input, pattern))
        {
            Console.WriteLine("Invalid Sentence");
            return;
        }
        
        string[] arr = input.Split(" ");
        Console.WriteLine("Word Count: "+arr.Length);
        if (arr.Length % 2 == 0)
        {
            Array.Reverse(arr);
            Console.WriteLine(string.Join(" ",arr));
        }
        else
        {
            foreach(string s in arr)
            {
                char[] charArr = s.ToCharArray();
                Array.Reverse(charArr);
                Console.Write(new string(charArr)+" ");
            }
        }
    }
}