using System.Collections.Generic;
using Domain;
using Exceptions;
using System.Linq;

namespace Services
{
    public class AccountService
    {
        private SortedDictionary<decimal, List<Account>> _data = new SortedDictionary<decimal, List<Account>>();

        public void AddSampleData()
        {
            _data[1000]=new List<Account>{new Account{AccountNumber=1, HolderName="Rohit1",Balance=1000}};
            _data[2000]=new List<Account>{new Account{AccountNumber=2, HolderName="Rohit2",Balance=2000}};
            _data[3000]=new List<Account>{new Account{AccountNumber=3, HolderName="Rohit3",Balance=3000}};
        }

        public void Deposit(int accountNumber, decimal amount)
        {
            Account? target = null;
            decimal oldBalance = 0;
            bool found = false;

            foreach (var pair in _data)
            {
                foreach (var acc in pair.Value)
                {
                    if (acc.AccountNumber == accountNumber)
                    {
                        target = acc;
                        oldBalance = pair.Key;
                        found = true;
                        break;
                    }
                }
                if (found) break;
            }

            if (!found)
            {
                throw new AccountNotFoundException("Account not found");
            }

            _data[oldBalance].Remove(target!);

            target!.Balance += amount;
            decimal newBalance = target.Balance;

            if (!_data.ContainsKey(newBalance))
            {
                _data[newBalance] = new List<Account>();
            }

            _data[newBalance].Add(target);
        }

        public void Withdraw(int accountNumber, decimal amount)
        {
            Account? target = null;
            decimal oldBalance = 0;
            bool found = false;

            foreach (var pair in _data)
            {
                foreach (var acc in pair.Value)
                {
                    if (acc.AccountNumber == accountNumber)
                    {
                        target = acc;
                        oldBalance = pair.Key;
                        found = true;
                        break;
                    }
                }
                if (found) break;
            }

            if (!found)
            {
                throw new AccountNotFoundException("Account not found");
            }

            if (target!.Balance < amount)
            {
                throw new InsufficientFundsException("Insufficient balance");
            }

            _data[oldBalance].Remove(target);

            target.Balance -= amount;
            decimal newBalance = target.Balance;

            if (!_data.ContainsKey(newBalance))
            {
                _data[newBalance] = new List<Account>();
            }

            _data[newBalance].Add(target);
        }

        public void DisplayAccounts()
        {
            foreach (var pair in _data)
            {
                foreach (var acc in pair.Value)
                {
                    Console.WriteLine($"Account:{acc.AccountNumber} Name:{acc.HolderName} Balance:{acc.Balance}");
                }
            }
        }  
    }
}
