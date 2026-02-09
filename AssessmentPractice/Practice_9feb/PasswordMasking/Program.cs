public class Password
{
    public string? password{get; set;}

    public string getPassword(string input)
    {
        if (input.Length < 3)
        {
            return input;
        }

        int len = input.Length;
        string s = new string('*',len-2);
        password = input[0]+s+input[len-1];
        return password;
    }
}

public class Program
{
    public static void Main()
    {
        Password password = new Password();
        string input = Console.ReadLine()!;
        Console.WriteLine(password.getPassword(input));
    }
}