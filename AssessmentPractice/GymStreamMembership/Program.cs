public class InvalidTierException : Exception
{
    public InvalidTierException(string message) : base(message)
    {
        
    }   
}

public class Membership
{
    public string? Tier{get; set;}
    public int DurationInMonths{get; set;}
    public double BasePricePerMonth{get; set;}

    public bool ValidateEnrollment()
    {
        if(!(Tier=="Basic" || Tier=="Premium" || Tier == "Elite"))
        {
            throw new InvalidTierException("Error: Tier not recognized");
        }

        if (DurationInMonths < 0)
        {
            throw new Exception();
        }

        return true;
    }

    public double CalculateTotalBill()
    {
        double total;
        total = DurationInMonths*BasePricePerMonth;
        if (Tier == "Basic")
        {
            total-=total*0.2;
        }
        else if (Tier == "Premium")
        {
            total -= total*0.7;
        }
        else if(Tier == "Elite")
        {
            total -= total*0.12;
        }

        return total;
    }
}


public class Program
{
    public static void Main()
    {
        Console.WriteLine("Enter Tier : ");
        string tier = Console.ReadLine()!;
        Console.WriteLine("Enter Duration : ");
        int duration = int.Parse(Console.ReadLine()!);
        Console.WriteLine("Enter Price");
        double price = double.Parse(Console.ReadLine()!);

        Membership membership = new Membership();
        membership.BasePricePerMonth=price;
        membership.DurationInMonths=duration;
        membership.Tier=tier;

        
        try
        {
            membership.ValidateEnrollment();
            Console.WriteLine("Enrollment Successful");
            double result = membership.CalculateTotalBill();
            Console.WriteLine($"Total bill : {result:F2}");
        }
        catch(InvalidTierException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}