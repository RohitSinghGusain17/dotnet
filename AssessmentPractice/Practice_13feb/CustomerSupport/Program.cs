public class Program
{
    public static void Main()
    {
        //Customer Support – Merge Two Ticket Streams
        //Output must remain sorted ascending.
        //Avoid full re-sort; target O(n+m).

        List<int> a = new List<int> {1,4,7};
        List<int> b = new List<int> {2,3,8};
        List<int> merged = new List<int>();

        int aLeft=0;
        int bLeft=0;
        int aRight=a.Count;
        int bRight=b.Count;

        while(aLeft<aRight && bLeft<bRight)
        {
            if (a[aLeft] == b[aLeft])
            {
                merged.Add(a[aLeft++]);
                merged.Add(b[bLeft++]);
            }
            else if (a[aLeft] > b[bLeft])
            {
                merged.Add(b[bLeft++]);
            }
            else
            {
                merged.Add(a[aLeft++]);
            }
        }

        while (aLeft < aRight)
        {
            merged.Add(a[aLeft++]);
        }
        while(bLeft < bRight)
        {
            merged.Add(b[bLeft++]);
        }

        foreach(var i in merged)
        {
            Console.WriteLine(i);
        }
    }
}