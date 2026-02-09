public class Program
{
    public static void Main()
    {
        string input = Console.ReadLine()!;
        Dictionary<string, int> freq = new Dictionary<string, int>();

        input = input.ToLower();
        string[] splitInput = input.Split(" ");
        foreach(var i in splitInput)
        {
            if (freq.ContainsKey(i))
            {
                freq[i]++;
            }
            else
            {
                freq[i]=1;
            }
        }

        foreach(var i in freq)
        {
            Console.WriteLine(i.Key+" "+i.Value);
        }
    }
}