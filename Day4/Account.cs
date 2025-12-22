using System;

namespace account
{
    public class Account
    {
        public string? name{get; set;}
        public int? AccountId{get; set;}

        public string GetAccountDetails()
        {
            return $"I am in base class\nname : {name}\nAccountID : {AccountId}";
        }
    }

    public class SalesAccount : Account
    {
        public string GetSalesAccountDetails()
        {
            string info = string.Empty;
            info+=base.GetAccountDetails();
            info+="\nI am in derived class";
            return info;
        }

        public string? salesInfo{get; set;}
    }

    public class PurchaseAccount : Account
    {
        public string? purchaseInfo{get; set;}
    }
}