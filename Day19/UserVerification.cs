public class UserVerification
{
    public string? Name{get; set;}
    public string? PhoneNumber{get; set;}

    public UserVerification ValidatePhoneNumbner(string name, string phonenumber)
    {
        if (phonenumber.Length == 10)
        {
            return new UserVerification{Name=name, PhoneNumber=PhoneNumber};
        }
        else
        {
            throw new InvalidPhoneNumberException("Invalid phone number");
        }
    }
}

public class InvalidPhoneNumberException : Exception
{
    public InvalidPhoneNumberException(string message) : base(message)
    {
        
    }
}