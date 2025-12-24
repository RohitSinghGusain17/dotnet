namespace LoginAbs
{
        public abstract class Login
        {
            protected string name = "Rohit";
            public abstract void LoginFunc(string username, string password);
        }

    public class Authentication : Login
    {   
        public override void LoginFunc(string username, string password)
        {
            Console.WriteLine(name);
            if (username.Equals("user") && password.Equals("pass"))
            {
                Console.WriteLine("Login Success");
            }
            else
            {
                Console.WriteLine("Login Failed");
            }
        }
    }
}
