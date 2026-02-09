using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CSharp.Adv_Practice
{
    public class Customer
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }

    public class DuplicateDetector
    {
        public List<List<Customer>> FindDuplicates(List<Customer> customers)
        {
            return customers
                .GroupBy(c => c.Email ?? c.Phone)
                .Where(g => g.Count() > 1)
                .Select(g => g.ToList())
                .ToList();
        }
    }

    [TestFixture]
    public class DuplicateDetectorTest
    {
        [Test]
        public void DuplicatesDetected()
        {
            var list = new List<Customer>
            {
                new Customer{Name="Rohit",Email="abc@x.com"},
                new Customer{Name="Ravi",Email="pqr@x.com"}
            };

            var result = new DuplicateDetector().FindDuplicates(list);
            Assert.That(result.Count, Is.EqualTo(1));
        }
    }
}