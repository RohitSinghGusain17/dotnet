using System.Collections.Generic;
using Domain;
using Exceptions;

namespace Services
{
    public class OrderService
    {
        private SortedDictionary<int, List<Order>> _data = new SortedDictionary<int, List<Order>>();

        public void AddOrder(Order order)
        {
            if (order.OrderAmount <= 0)
            {
                throw new InvalidOrderAmountException("Amount must be positive");
            }

            if (!_data.ContainsKey(order.OrderAmount))
            {
                _data[order.OrderAmount] = new List<Order>();
            }

            _data[order.OrderAmount].Add(order);
        }

        public void UpdateOrder(int orderId, int newAmount)
        {
            if (newAmount <= 0)
            {
                throw new InvalidOrderAmountException("Invalid amount");
            }

            Order? target = null;
            int oldAmount = 0;
            bool found = false;

            foreach (var pair in _data)
            {
                foreach (var o in pair.Value)
                {
                    if (o.OrderId == orderId)
                    {
                        target = o;
                        oldAmount = pair.Key;
                        found = true;
                        break;
                    }
                }
                if (found) break;
            }

            if (!found)
            {
                throw new OrderNotFoundException("Order not found");
            }

            _data[oldAmount].Remove(target!);

            if (_data[oldAmount].Count == 0)
            {
                _data.Remove(oldAmount);
            }

            target!.OrderAmount = newAmount;

            if (!_data.ContainsKey(newAmount))
            {
                _data[newAmount] = new List<Order>();
            }

            _data[newAmount].Add(target);
        }

        public void DisplayOrders()
        {
            foreach (var pair in _data.Reverse())
            {
                foreach (var order in pair.Value)
                {
                    Console.WriteLine($"OrderID: {order.OrderId}, CustomerName : {order.CustomerName}, OrderAmount: {order.OrderAmount}");
                }
            }
        }
    }
}
