
using System.Text.RegularExpressions;

public class Shipment
{
    public string? ShipmentCode{get; set;}
    public string? TransportMode{get; set;}
    public double Weight{get; set;}
    public int StorageDays{get; set;}
}

public class ShipmentDetails : Shipment
{
    public bool ValidateShipmentCode()
    {
        string pattern = @"^GC#[0-9]{4}$";
        if (Regex.IsMatch(ShipmentCode!, pattern))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public double RatePerKg(string mode)
    {
        double rate=0;
        switch (mode){
            case "Sea":
                rate=15.00;
                break;
            case "Air":
                rate = 50.00;
                break;
            case "Land":
                rate = 25.00;
                break;
        }

        return rate;
    }

    public double CalculateTotalCost()
    {
        double TotalCost = Weight*RatePerKg(TransportMode!) + Math.Sqrt(StorageDays);
        return Math.Round(TotalCost,2);
    }
}

public class Program
{
    public static void Main()
    {
        ShipmentDetails shipmentDetails = new ShipmentDetails();
        Console.WriteLine("Enter shipment code : ");
        string code = Console.ReadLine()!;
        shipmentDetails.ShipmentCode=code;

        if (shipmentDetails.ValidateShipmentCode())
        {
            Console.WriteLine("Enter transport mode : ");
            string mode = Console.ReadLine()!;
            Console.WriteLine("Enter weight : ");
            double weight = double.Parse(Console.ReadLine()!);
            Console.WriteLine("Enter storage days : ");
            int days = int.Parse(Console.ReadLine()!);

            shipmentDetails.StorageDays=days;
            shipmentDetails.Weight=weight;
            shipmentDetails.TransportMode=mode;

            double result = shipmentDetails.CalculateTotalCost();
            Console.WriteLine("Total Shipment Cost is "+result);
        }
        else
        {
            Console.WriteLine("Invalid Shipment Code");
        }
    }
}