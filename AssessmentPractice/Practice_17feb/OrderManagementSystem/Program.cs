public class Product
{
    public int ID{get; set;}
    public string? Name{get; set;}
    public double Price{get; set;}
    public int Stock{get; set;}
}

public class Order
{
    public int OrderID{get; set;}
    public Customer Customer{get; set;}
    public List<OrderItem> orderItem;
    public DateTime OrderDate{get; set;}
    public string? OrderStatus{get; set;}
}

public class OrderItem
{
    public Product Product{get; set;}
    public int Quantity{get; set;}
    public double TotalPrice()
    {
        return Product.Price*Quantity; 
    }
}

public class Customer
{
    public int ID{get; set;}
    public string? Name{get; set;}
}

public class Program
{
    public static List<Product> products = new List<Product>();
    public static List<Customer> customers = new List<Customer>();
    public static List<Order> orders = new List<Order>();
    public static Dictionary<Product, int> itemSold = new Dictionary<Product, int>();
    public static Dictionary<Customer, double> spending = new Dictionary<Customer, double>();
    public static void Main()
    {
        products.Add(new Product{ID=1001, Name="Charger", Price=300, Stock=5});
        products.Add(new Product{ID=1002, Name="Cable", Price=100, Stock=7});
        products.Add(new Product{ID=1003, Name="Smartphone", Price=30000, Stock=3});
        products.Add(new Product{ID=1004, Name="Earphone", Price=300, Stock=5});

        customers.Add(new Customer{ID=101, Name="Rohit1"});
        customers.Add(new Customer{ID=102,Name="Rohit2"});
        customers.Add(new Customer{ID=103, Name="Rohit3"});
        customers.Add(new Customer{ID=104,Name="Rohit4"});

        orders.Add(new Order{OrderID=001,Customer=customers[1], OrderDate=DateTime.Now, OrderStatus="Accepted",
        orderItem=new List<OrderItem>{new OrderItem{Product=products[0], Quantity=2},
        new OrderItem{Product=products[1], Quantity=3}
        }});

        orders.Add(new Order{OrderID=002,Customer=customers[2], OrderDate=DateTime.Now, OrderStatus="Accepted",
        orderItem=new List<OrderItem>{new OrderItem{Product=products[0], Quantity=2},
        new OrderItem{Product=products[2], Quantity=3}
        }});

        foreach(var i in orders)
        {
            foreach(var j in i.orderItem)
            {
                if(itemSold.ContainsKey(j.Product))
                    itemSold[j.Product]+=j.Quantity;
                else
                    itemSold[j.Product]=j.Quantity;
            }
        }

        foreach(var i in orders)
        {
            foreach(var j in i.orderItem)
            {
                if (spending.ContainsKey(i.Customer))
                {
                    spending[i.Customer]+=j.TotalPrice();
                }
                else
                {
                    spending[i.Customer]=j.TotalPrice();
                }
            }
        }

        //Get all orders placed in last 7 days
        var ordersPlaced = orders.Where(x=>x.OrderDate>=DateTime.Now.AddDays(-7)).ToList();
        foreach(var i in ordersPlaced)
        {
            Console.WriteLine($"{i.OrderID} {i.Customer} {i.OrderStatus}");
        }

        //Get total revenue
        var totalRevenue = orders.Sum(x=>x.orderItem.Sum(y=>y.TotalPrice()));
        Console.WriteLine("Total Revenue : "+totalRevenue);

        //Get most sold product
        var mostSold = itemSold.OrderByDescending(x=>x.Value).First();
        Console.WriteLine($"{mostSold.Key.Name}");

        //Get top 5 customers by spending
        var topCustomer = spending.OrderByDescending(x=>x.Value).Take(5).ToList();
        foreach(var i in topCustomer)
        {
            Console.WriteLine($"{i.Key.ID} {i.Key.Name}");
        }

        //Group orders by status
        var status = orders.GroupBy(x=>x.OrderStatus).ToList();
        foreach(var i in status)
        {
            Console.WriteLine(i.Key);
            foreach(var j in i.ToList())
            {
                Console.WriteLine($"order id : {j.OrderID}, customer : {j.Customer}");
            }
        }

        //Find products with stock < 10
        var stocks = products.Where(x => x.Stock < 10);
        foreach(var i in stocks)
        {
            Console.WriteLine($"ID : {i.ID}, Name : {i.Name}");
        }
    }
}