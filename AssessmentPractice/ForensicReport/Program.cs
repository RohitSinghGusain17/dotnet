public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter number of reports to be added");
        int number = int.Parse(Console.ReadLine()!);
        Console.WriteLine("Enter the forensic reports (Reporting Officer:Report Filed Date)");
        ForensicReport forensicReport = new ForensicReport();
        for(int i = 0; i < number; i++)
        {
            string report = Console.ReadLine()!;
            string[] reportDetail = report.Split(":");
            forensicReport.addReportDetails(reportDetail[0],DateOnly.Parse(reportDetail[1]));
        }

        Console.WriteLine("Enter the filed date to identify the reporting officers");
        DateOnly date = DateOnly.Parse(Console.ReadLine()!);
        Console.WriteLine($"Reports filed on the {date} are by");
        var result = forensicReport.getOfficersWhoFiledReportsOnDate(date);
        if (result.Count == 0)
        {
            Console.WriteLine("No reporting officer filed the report");
        }
        else
        {
            foreach(var i in result)
            {
                Console.WriteLine(i);
            }
        }
    }
}