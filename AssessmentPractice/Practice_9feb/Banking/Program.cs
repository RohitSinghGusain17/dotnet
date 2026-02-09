public class BankAccount
{
    private double Balance{get; set;}

    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            Balance+=amount;
        }
        else
        {
            Console.WriteLine("Amount should be greater than 0");
        }      
    }

    public void Withdraw(double amount)
    {
        if(amount>0 && amount <= Balance)
        {
            Balance-=amount;
        }
        else
        {
            Console.WriteLine("Amount should less than or equal to zero");
        }
    }

    public void getBalance()
    {
        Console.WriteLine("Remaining balance : "+Balance);
    }
}


public class Program
{
    public static void Main()
    {
        BankAccount bankAccount = new BankAccount();
        bankAccount.Deposit(2000);
        bankAccount.Deposit(2000);
        bankAccount.Deposit(2000);
        bankAccount.Withdraw(2000);
        bankAccount.Withdraw(2000);
        bankAccount.getBalance();
    }
}