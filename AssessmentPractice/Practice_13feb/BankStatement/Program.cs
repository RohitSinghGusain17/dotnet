public class Program
{
    public static void Main()
    {
        //Bank Statement – Spend by Category
        //Only amounts < 0 contribute to spend.
        //Store spend totals as positive values (e.g., -120 => 120).

        List<(string category, decimal amount)> txns = new List<(string category, decimal amount)> {("Food",-200),("Fuel",-500),("Food",-50),("Salary",1000)};
        Dictionary<string, decimal> spendByCategory = new Dictionary<string, decimal>();

        foreach(var i in txns)
        {
            if (i.amount < 0)
            {
                if (spendByCategory.ContainsKey(i.category))
                {
                    spendByCategory[i.category]+=Math.Abs(i.amount);
                }
                else
                {
                    spendByCategory[i.category]=Math.Abs(i.amount);
                }
            }
        }

        foreach(var i in spendByCategory)
        {
            Console.WriteLine(i.Key+" "+i.Value);
        }
    }
}