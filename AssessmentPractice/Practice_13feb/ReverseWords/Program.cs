using System.Text.RegularExpressions;
public class Program
{

    public static void Main()
    {
        //https://leetcode.com/problems/reverse-words-in-a-string/
        string s = Console.ReadLine()!;
        s=s.Trim();
        Console.WriteLine(string.Join(" ", Regex.Split(s,@"\s+").Reverse().ToArray()));
    }
}