public abstract class DiscountPolicy
{
    public abstract double GetFinalAmount(double amount);
}

public class FestivalDiscount : DiscountPolicy
{
    public override double GetFinalAmount(double amount)
    {
        if (amount >= 5000)
        {
            amount=amount-amount*0.10;
        }
        else
        {
            amount=amount-amount*0.05;
        }

        return amount;
    }
}

public class MemberDiscount : DiscountPolicy
{
    public override double GetFinalAmount(double amount)
    {
        if (amount >= 2000)
        {
            amount=amount-300;
        }

        return amount;
    }
}

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Enter policy : ");
        string policy = Console.ReadLine()!;
        if (policy == "FestivalDiscount")
        {
            FestivalDiscount festivalDiscount = new FestivalDiscount();
            Console.WriteLine("Enter amount : ");
            double amount = double.Parse(Console.ReadLine()!);
            Console.WriteLine(festivalDiscount.GetFinalAmount(amount));
        }
        else if (policy == "MemberDiscount")
        {
            MemberDiscount memberDiscount = new MemberDiscount();
            Console.WriteLine("Enter amount : ");
            double amount = double.Parse(Console.ReadLine()!);
            Console.WriteLine(memberDiscount.GetFinalAmount(amount));
        }
    }
}