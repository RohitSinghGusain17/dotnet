public class Program
{
    public string CleanseAndInvert(string input)
    {
        string ans="";
        if(input=="" || input.Length < 6 || input.Contains(" "))
        {
            return "";
        }
        foreach(char i in input)
        {
            if (!char.IsLetter(i))
            {
                return "";
            }
        }

        string lowerInput = input.ToLower();
        foreach(char i in lowerInput)
        {
            if ((int)i % 2 != 0)
            {
                ans+=i.ToString();
            }
        }
        char[] revString = ans.ToCharArray();
        Array.Reverse(revString);

        string result="";
        for(int i = 0; i < revString.Length; i++)
        {
            if (i % 2 == 0)
            {
                result+=revString[i].ToString().ToUpper();
            }
            else
            {
                result+=revString[i].ToString();
            }
        }

        return result;

    }
    public static void Main(string[] args)
    {
        string input = Console.ReadLine()!;
        Program p = new Program();
        string ans = p.CleanseAndInvert(input);
        if (ans == "")
        {
            Console.WriteLine("Invalid Input");
        }
        else
        {
            Console.WriteLine("The generated key is - "+ans);
        }
    }
}