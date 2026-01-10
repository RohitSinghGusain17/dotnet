// 1) Create a delegate type (signature: void (string))
public delegate void Notify(string message);

class OrderService
{
    // 2) Accept a delegate as parameter (callback)
    public void PlaceOrder(string orderId, Notify callback)
    {
        Console.WriteLine($"Order {orderId} placed.");

        // 3) Call the callback (when something important happens)
        callback?.Invoke($"Order {orderId} confirmation sent!");
    }
}