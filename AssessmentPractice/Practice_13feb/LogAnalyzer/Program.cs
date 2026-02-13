public class Program
{
    public static void Main()
    {
        //Log Analyzer – Most Frequent Error Code
        //Return the code with highest frequency.
        //If tie, return the smallest code (lexicographic order).

        List<string> codes = new List<string> {"E02","E01","E02","E01","E03"};
        Dictionary<string, int> freq = new Dictionary<string, int>();

        foreach(var i in codes)
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

        string result = freq.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key).First().Key;
        Console.WriteLine(result);
    }
}