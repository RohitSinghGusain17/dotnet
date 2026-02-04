using System;
public class LoginAttemptLimitReached : Exception
{
    public LoginAttemptLimitReached(string message) : base(message)
    {

    }
}

public class LoginSystem
{
    public static void Main()
    {
        int attempts = 0;
        string password = "admin";
        // 1. Allow only 3 login attempts
        try
        {
            while (true)
            {
                Console.WriteLine("Enter password : ");
                string input = Console.ReadLine()!;
                if (password != input)
                {
                    attempts++;
                    Console.WriteLine("Try Again");
                }
                else if (password == input)
                {
                    Console.WriteLine("Login Successfully");
                    break;
                }
                if (attempts >= 3)
                {
                    // 3. Handle exception and terminate application
                    throw new LoginAttemptLimitReached("Your 3 attempts limit Reached.. Try again after 3 hours");
                }
            }
        }
        // 2. Create and throw custom exception after limit
        catch (LoginAttemptLimitReached ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}