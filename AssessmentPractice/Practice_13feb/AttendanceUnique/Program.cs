public class Program
{
    public static void Main()
    {
        //Attendance – First Unique Entry
        //Return only the first occurrence of each ID.
        //Maintain original order for first-time entries.

        //HashSet<int> uniqueScans = new HashSet<int>();
        List<int> uniqueScans = new List<int>();
        List<int> scans = new List<int> {10, 20, 50, 50, 10, 25, 30, 20, 40};

        foreach(var i in scans)
        {
            if (!uniqueScans.Contains(i))
            {
                uniqueScans.Add(i);
            }
        }

        foreach (var i in uniqueScans)
        {
            Console.WriteLine(i);
        }
    }
}