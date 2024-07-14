using System.Collections.Generic;
using System.Linq;

namespace Treefrog.Models
{
    public class Order
    {
        private static readonly TimeSpan DefaultCollectionTimeOffset = TimeSpan.FromMinutes(25);
        private static readonly Random RandomGenerator = new Random();

        public string OrderNumber { get; set; }
        public List<MenuItem> Items { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime CollectionDate { get; set; }
        public string Status { get; set; }
        public decimal TotalPrice { get; set; }

        public Order()
        {
            OrderNumber = GetNextOrderNumber();
            OrderDate = DateTime.Now;
            CollectionDate = OrderDate.Add(DefaultCollectionTimeOffset);
            Status = "Confirmed";
            Items = new List<MenuItem>();
        }

        public Order(IEnumerable<MenuItem> items) : this()
        {
            Items = items.ToList();
            CalculateTotalPrice();
        }

        public Order(List<MenuItem> items, string orderNumber, string status, DateTime? collectionDate = null, decimal totalPrice = 0) : this()
        {
            Items = items ?? new List<MenuItem>();
            OrderNumber = OrderNumber = orderNumber ?? GetNextOrderNumber();
            Status = status;
            CollectionDate = collectionDate ?? OrderDate.Add(DefaultCollectionTimeOffset);
            TotalPrice = totalPrice != 0 ? totalPrice : CalculateTotalPrice();
        }

        private decimal CalculateTotalPrice()
        {
            return Items.Sum(item => item.Price * item.Quantity);
        }

        public string GetNextOrderNumber()
        {
            int randomOrderNumber = RandomGenerator.Next(100000, 999999); // Generate a random 6-digit number
            return randomOrderNumber.ToString("D6"); // Ensure it's formatted as a 6-digit number
        }
    }
}