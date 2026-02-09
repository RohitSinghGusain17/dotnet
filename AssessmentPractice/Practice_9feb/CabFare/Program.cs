public class Cab
{
    public virtual double CalculateFare(int km)
    {
        return 0;
    }
}

public class Mini : Cab
{
    public override double CalculateFare(int km)
    {
        return km*12;
    }
}

public class Sedan : Cab
{
    public override double CalculateFare(int km)
    {
        return km*15+50;
    }
}

public class SUV : Cab
{
    public override double CalculateFare(int km)
    {
        return km*18+100;
    }
}

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Enter cab type: ");
        string type = Console.ReadLine()!;
        Console.WriteLine("Enter km : ");
        int km = int.Parse(Console.ReadLine()!);
        if (type == "Mini")
        {
            Mini mini = new Mini();
            Console.WriteLine(mini.CalculateFare(km));
        }
        else if(type == "Seden")
        {
            Sedan sedan = new Sedan();
            Console.WriteLine(sedan.CalculateFare(km));
        }
        else if(type == "SUV")
        {
            SUV suv = new SUV();
            Console.WriteLine(suv.CalculateFare(km));
        }
    }
}