public class Program
{
    public static void Main()
    {
        int[] arr = [10, 20, 30, 40, 50];
        Console.WriteLine("Enter k : ");
        int k = int.Parse(Console.ReadLine()!);
        int n = arr.Length;
        k=k%n;

        int[] result = new int[n];
        int index=0;

        for(int i = n - k; i < n; i++)
        {
            result[index++]=arr[i];
        }

        for(int i = 0; i < n-k; i++)
        {
            result[index++]=arr[i];
        }

        for(int i = 0; i < n; i++)
        {
            Console.WriteLine(result[i]);
        }
    }
}