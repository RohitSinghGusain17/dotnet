public class EcommerceShop
{
    public string? UserName{get; set;}
    public double WalletBalance{get; set;}
    public double TotalPurchaseAmount{get; set;}

    public EcommerceShop MakePayment(string name, double balance, double amount)
    {
        return new EcommerceShop{UserName=name, WalletBalance=balance, TotalPurchaseAmount=amount};
    }
}

public class InsufficientWalletBalanceException : Exception
{
    public InsufficientWalletBalanceException(string Message) : base(Message)
    {
      
    }
}