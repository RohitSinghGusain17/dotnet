public class User
{
    public string? Name{get; set;}
    public string? Password{get; set;}
    public string? confirmPassword{get; set;}

    public User ValidatePassword(string name, string password, string confirm)
    {
        if (password != confirm)
        {
            throw new PasswordMismatchException("PAssword not matched");
        }
        else
        {
            return new User{Name=name, Password=password, confirmPassword= confirm};
        }
    }
}

public class PasswordMismatchException : Exception
{
    public PasswordMismatchException(string message) : base(message)
    {
        
    }
}