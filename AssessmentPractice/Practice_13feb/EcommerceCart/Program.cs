public class Program
{
    public static void Main()
    {
        //E-Commerce Cart Consolidation
        // If SKU repeats, sum quantities.
        // Ignore scans where qty <= 0.
        List<(string sku, int qty)> scans = new List<(string sku, int qty)> {("A101",2),("B205",1),("A101",3),("C111",-1)};
        Dictionary<string, int> skuQty = new Dictionary<string, int>();

        foreach(var i in scans)
        {
            if (i.qty > 0)
            {
                if (skuQty.ContainsKey(i.sku))
                {
                    skuQty[i.sku]+=i.qty;
                }
                else
                {
                    skuQty[i.sku]=i.qty;
                }
            }    
        }

        foreach(var i in skuQty)
        {
            Console.WriteLine(i.Key+" "+i.Value);
        }
    }
}