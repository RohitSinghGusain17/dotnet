public class Program
{
    public static void Main()
    {
        //Inventory – Detect Duplicate Serials
        //Return each duplicate only once.
        //Preserve the order they are first detected as duplicate.

        List<string> serials = new List<string> {"S1","S2","S1","S3","S2","S2"};
        List<string> duplicates = new List<string>();
        HashSet<string> unique = new HashSet<string>();

        foreach(var i in serials)
        {
            if(!unique.Add(i) && !duplicates.Contains(i))
            {
                duplicates.Add(i);
            }
        }

        Console.WriteLine(string.Join(", ",duplicates));
        
    }
}