using System.Text.RegularExpressions;

public class Program
{
    public static void Main()
    {
        string input = Console.ReadLine()!;
        string[] inputSplit = Regex.Split(input, @"[^A-Za-z]+");
        int maxLen=0;
        string result ="";

        foreach(var i in inputSplit)
        {
            if (i == "") continue;
            
            int len = i.Length;
            if (len > maxLen)
            {
                result=i;
                maxLen=len;
            }
        }

        Console.WriteLine(result);
    }
}