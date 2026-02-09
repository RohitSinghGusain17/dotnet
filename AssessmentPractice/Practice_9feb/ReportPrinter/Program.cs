public class Program
{
    public static void PrintReport(string title, int copies=1, bool showHeader = true)
    {
        Console.WriteLine($"{title} {copies} {showHeader}");
    }
    public static void Main()
    {
        PrintReport("abc",2,false);
    }
}