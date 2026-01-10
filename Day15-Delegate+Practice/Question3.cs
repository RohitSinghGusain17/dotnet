public enum CommodityCategory
{
    Furniture,
    Grocery,
    Service
}
class Commodity
{
    public CommodityCategory Category { get; set; }
    public string CommodityName { get; set; }
    public int CommodityQuantity { get; set; }
    public double CommodityPrice { get; set; }
    public Commodity(CommodityCategory category, string commodityName, int commodityQuantity, double commodityPrice)
    {
        Category = category;
        CommodityName = commodityName;
        CommodityQuantity = commodityQuantity;
        CommodityPrice = commodityPrice;
    }
}
class PrepareBill
{
    readonly IDictionary<CommodityCategory,double> _taxRates=new Dictionary<CommodityCategory,double>();
    public void SetTaxRates(CommodityCategory category, double taxRate)
    {
        if (!_taxRates.ContainsKey(category))
        {
            _taxRates[category]=taxRate;
        }
        else
        {
            Console.WriteLine("Category Already exist");
        }
    }
    public double CalculateBillAmount(IList<Commodity> items)
    {
        double total=0;
        foreach(Commodity c in items)
        {
            if (_taxRates.ContainsKey(c.Category))
            {
                total+=c.CommodityPrice;
            }
            else
            {
                throw new ArgumentException(c.Category+" Category not exist");
            }
        }
        return total;
    }
}