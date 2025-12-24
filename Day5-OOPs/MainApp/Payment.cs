namespace payment
{
    abstract class Payment
    {
        public double amount;
        protected Payment(double amountInput)
        {
            amount=amountInput;
        }

        public void PrintRecipt()
        {
            Console.WriteLine("Amount is : "+amount);
        }

        public abstract void Pay();
    }

    class UPIpayment : Payment
    {
        public string UPIid;
        public UPIpayment(double amountInput, string UPIidInput) : base(amountInput)
        {
            UPIid=UPIidInput;
        }

        public override void Pay()
        {
            Console.WriteLine($"You paid {amount} using upi id {UPIid}");
        }
    }
}