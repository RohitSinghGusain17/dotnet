using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CSharp.Adv_Practice
{
    public class Product
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
    }

    public class OrderItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }

    public class Orders
    {
        public List<OrderItem> Items { get; } = new List<OrderItem>();
    }

    public class OrderService
    {
        public void AddItem(Orders order, Product product, int qty)
        {
            if (product.Stock < qty) throw new InvalidOperationException();
            order.Items.Add(new OrderItem { Product = product, Quantity = qty });
        }

        public decimal PlaceOrder(Orders order)
        {
            decimal total = 0;

            foreach (var item in order.Items)
            {
                if (item.Product.Stock < item.Quantity)
                    throw new InvalidOperationException();

                item.Product.Stock -= item.Quantity;
                total += item.Product.Price * item.Quantity;
            }

            return total;
        }
    }

    [TestFixture]
    public class OrderServiceTests
    {
        [Test]
        public void OrderIsPlacedAndStockReduced()
        {
            var product = new Product { Name = "Notebook", Stock = 100, Price = 100 };
            var order = new Orders();
            var service = new OrderService();

            service.AddItem(order, product, 2);
            var total = service.PlaceOrder(order);

            Assert.That(total, Is.EqualTo(200));
            Assert.That(product.Stock, Is.EqualTo(8));
        }
    }
}