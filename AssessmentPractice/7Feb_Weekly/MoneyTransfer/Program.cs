using NUnit.Framework;
public class TransferResult
{
    public string? message{get; set;}
}

public class DomainException : Exception
{
    public DomainException(string message) : base(message)
    {
        
    }
}

public class MoneyTransfer
{
    public decimal balance=10000;

    public TransferResult Transfer(string fromAcc, string toAcc, decimal amount)
    {
        if (fromAcc == toAcc)
        {
            throw new DomainException("Error : entered Same Account");
        }
        if (amount > balance)
        {
            throw new DomainException("Amount entered is greater than balance available");
        }
        if (amount <= 0)
        {
            throw new DomainException("Amount Should be greater than 0");
        }
        balance-=amount;
        TransferResult result = new TransferResult();
        result.message="Success";
        return result;
    }
}

[TestFixture]
public class Test_MoneyTransfer
{
    [Test]
    public void Test_Transfer()
    {
        MoneyTransfer transfer = new MoneyTransfer();
        var test1 = transfer.Transfer("34567865434", "34566543435", 222);

        Assert.That(test1.message,Is.EqualTo("Success"));
        Assert.Throws<DomainException>(()=> transfer.Transfer("34536473456","76543245645",0));
    }
}
