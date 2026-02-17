public abstract class BankAccount
{
    public int AccountNumber{get; set;}
    public string? CustomerName{get; set;}
    public double Balance{get; set;}

    public void Deposit(double amount)
    {
        Balance+=amount;
    }
    public void Withdraw(int amount)
    {
        Balance-=amount;
    }
    public abstract double CalculateInterest();
}

public class SavingsAccount : BankAccount
{
    public void Withdraw(double amount)
    {
        if (amount > Balance)
        {
            throw new InsufficientBalanceException("Insufficient Balance");
        }

        double tempCheck = Balance-amount;
        double MinimumBalance = 1000;
        if (tempCheck < MinimumBalance)
        {
            throw new MinimumBalanceException("Minimum Balance is to be maintained");
        }


        Balance-=amount;
    }

    public override double CalculateInterest()
    {
        return 0;
    }
}

public class CurrentAccount : BankAccount
{
    public override double CalculateInterest()
    {
        return 0;
    }
}

public class LoanAccount : BankAccount
{
    public new void  Deposit(double amount)
    {
        throw new InvalidTransactionException("LoanAccount cannot deposit");
    }

    public override double CalculateInterest()
    {
        return 0;
    }
}

public class InvalidTransactionException : Exception
{
    public InvalidTransactionException(string message) : base(message){}
}

public class MinimumBalanceException : Exception
{
    public MinimumBalanceException(string message) : base(message){}
}

public class InsufficientBalanceException : Exception
{
    public InsufficientBalanceException(string message) : base(message){}
}

public class Program
{
    public static List<BankAccount> accounts = new List<BankAccount>();
    public static void Main()
    {
        accounts.Add(new LoanAccount{AccountNumber=001,CustomerName="rohit1",Balance=3000});
        accounts.Add(new SavingsAccount{AccountNumber=002,CustomerName="rohit2",Balance=400000});
        accounts.Add(new LoanAccount{AccountNumber=003,CustomerName="rohit3",Balance=3000});
        accounts.Add(new SavingsAccount{AccountNumber=004,CustomerName="rohit4",Balance=200000});
        accounts.Add(new CurrentAccount{AccountNumber=005,CustomerName="rohit5",Balance=8000});

        //Get accounts with balance > 50,000
        var resultAccounts = accounts.Where(x=>x.Balance>50000).ToList();
        foreach(var i in resultAccounts)
        {
            Console.WriteLine($"{i.AccountNumber} {i.CustomerName}");
        } 

        //Get total bank balance
        var totalBalance = accounts.Sum(x=>x.Balance);
        Console.WriteLine("Total Balance : "+totalBalance);

        //Get top 3 highest balance accounts
        var highestAccount = accounts.OrderByDescending(x=>x.Balance).Take(3).ToList();
        foreach(var i in highestAccount)
        {
            Console.WriteLine($"{i.GetType()} {i.AccountNumber} {i.CustomerName}");
        }

        //Group accounts by account type
        var groupAccount = accounts.GroupBy(x=>x.GetType()).ToList();
        foreach(var i in groupAccount)
        {
            Console.WriteLine(i.Key);
            foreach(var j in i.ToList())
            {
                Console.WriteLine("Account Number : "+j.AccountNumber);
            }
        }

        //Find customers whose name starts with "R"
        var nameStarts = accounts.Where(x=>x.CustomerName.StartsWith("R")).ToList();
        foreach(var i in nameStarts)
        {
            Console.WriteLine($"{i.AccountNumber} {i.CustomerName}");
        }
    }
}