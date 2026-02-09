using System;
using NUnit.Framework;

public class Account
{
    public int Id;
    public decimal Balance;
    public readonly object LockObj = new object();
}

public class Bank
{
    public void SafeTransfer(Account a, Account b, decimal amount)
    {
        if (amount <= 0) throw new ArgumentException();

        var first = a.Id < b.Id ? a : b;
        var second = a.Id < b.Id ? b : a;

        lock (first.LockObj)
        {
            lock (second.LockObj)
            {
                if (a.Balance < amount) throw new InvalidOperationException();
                a.Balance -= amount;
                b.Balance += amount;
            }
        }
    }
}

[TestFixture]
public class BankTests
{
    [Test]
    public void Transfer_Works()
    {
        var a = new Account { Id = 1, Balance = 100 };
        var b = new Account { Id = 2, Balance = 50 };

        new Bank().SafeTransfer(a, b, 20);

        Assert.AreEqual(80, a.Balance);
        Assert.AreEqual(70, b.Balance);
    }

    [Test]
    public void NoDeadlock_WithOppositeOrder()
    {
        var a = new Account { Id = 1, Balance = 100 };
        var b = new Account { Id = 2, Balance = 100 };
        var bank = new Bank();

        var t1 = System.Threading.Tasks.Task.Run(() => bank.SafeTransfer(a, b, 10));
        var t2 = System.Threading.Tasks.Task.Run(() => bank.SafeTransfer(b, a, 10));

        System.Threading.Tasks.Task.WaitAll(t1, t2);

        Assert.AreEqual(100, a.Balance);
        Assert.AreEqual(100, b.Balance);
    }
}