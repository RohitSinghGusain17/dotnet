public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Enter Arm Precision(0.0-1.0):");
            double armPrecision = double.Parse(Console.ReadLine()!);
            Console.WriteLine("Enter Worker Density(1-20):");
            int workerDensity = int.Parse(Console.ReadLine()!);
            Console.WriteLine("Enter Machinery State (Worn/Faulty/Critical):");
            string machineryState = Console.ReadLine()!;
            RobotHazardAuditor robotHazardAuditor = new RobotHazardAuditor();
            double ans = robotHazardAuditor.CalculateHazardRisk(armPrecision, workerDensity, machineryState);
            Console.WriteLine("Robot Harard Risk Score: "+ans);
        }
        catch (RobotSafetyException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}