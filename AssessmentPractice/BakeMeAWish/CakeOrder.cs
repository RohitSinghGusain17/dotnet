public class CakeOrder
{
    private Dictionary<string, double> orderDict = new Dictionary<string, double>();

    public void addOrderDetails(string orderId, double cakeCost)
    {
        orderDict[orderId]=cakeCost;
    }

    public Dictionary<string, double> FindOrderAboveSpecifiedCost(double cakeCost)
    {
        var result = orderDict.Where(x=>x.Value>cakeCost).ToDictionary();
        return result;
    }
}