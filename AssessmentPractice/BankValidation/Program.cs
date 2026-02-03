using NUnit.Framework;
using System;

namespace BankAccountTests
{
    /// <summary>
    /// Represents a bank account.
    /// </summary>
    public class Program
    {
        public decimal Balance { get; private set; }

        public Program(decimal initialBalance)
        {
            Balance = initialBalance;
        }

        public void Deposit(decimal amount)
        {
            if (amount < 0)
                throw new Exception("Deposit amount cannot be negative");

            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount > Balance)
                throw new Exception("Insufficient funds.");

            Balance -= amount;
        }
    }

    /// <summary>
    /// Unit test class for bank account.
    /// </summary>
    [TestFixture]
    public class UnitTest
    {
        [Test]
        public void Test_Deposit_ValidAmount()
        {
            Program acc = new Program(1000);
            acc.Deposit(500);
            Assert.That(acc.Balance, Is.EqualTo(1500));
        }

        [Test]
        public void Test_Deposit_NegativeAmount()
        {
            Program acc = new Program(1000);
            Assert.Throws<Exception>(() => acc.Deposit(-100));
        }

        [Test]
        public void Test_Withdraw_ValidAmount()
        {
            Program acc = new Program(1000);
            acc.Withdraw(300);
            Assert.That(acc.Balance, Is.EqualTo(700));
        }

        [Test]
        public void Test_Withdraw_InsufficientFunds()
        {
            Program acc = new Program(500);
            Assert.Throws<Exception>(() => acc.Withdraw(1000));
        }
    }
}