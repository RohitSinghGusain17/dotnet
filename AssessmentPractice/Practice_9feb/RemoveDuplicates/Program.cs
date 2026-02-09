public class Program
{
    public static void Main()
    {
        int[] arr = [1,2,3,45,56,6,7,5,4,3,6,5];
        HashSet<int> values = new HashSet<int>();
        foreach(var i in arr)
        {
            values.Add(i);
        }
        
        foreach(var i in values)
        {
            Console.WriteLine(i);
        }
    }
}