using System.Collections.Frozen;
using System.Net.Security;
using System.Text;

public class FindItems
{
    public static SortedDictionary<string, long> itemDetails = new SortedDictionary<string, long>();
    public SortedDictionary<string, long> FindItemDetails(long soldCount)
    {
        SortedDictionary<string,long> ans = new SortedDictionary<string, long>();
        foreach (var item in itemDetails)
        {
            if (item.Value == soldCount)
            {
                ans.Add(item.Key,item.Value);
            }
        }

        return ans;
    }

    public List<string> FindMinandMaxSoldItems()
    {
        var itemDetailsSorted = itemDetails.ToList().OrderBy(x=>x.Value);
        List<string> ans = new List<string>();
        var item = itemDetailsSorted.ToList();
        ans.Add(item[0].Key);
        ans.Add(item[item.Count-1].Key);

        return ans;
    }

    public Dictionary<string, long> SortByCount()
    {
        var itemDetailsSorted = itemDetails.ToList().OrderBy(x=>x.Value);
        return itemDetailsSorted.ToDictionary();
    }
}