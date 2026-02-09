public class Payment
{
    public void MakePayment(ref double walletBalance, double amount)
    {
        if(amount>0 && amount <= walletBalance)
        {
            walletBalance-=amount;
        }
    }
}

public class Program
{
    public static void Main()
    {
        double balance = 1000;
        Payment payment = new Payment();
        payment.MakePayment(ref balance,100);
        Console.WriteLine("Balance Remaining : "+balance);
    }
}