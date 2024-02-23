
namespace Treefrog.Models
{
    public class Order
    {
        private static readonly TimeSpan DefaultCollectionTimeOffset = TimeSpan.FromMinutes(25);

        public string OrderNumber { get; set; }
        public List<MenuItem> Items { get; set; }
        public DateTime OrderDate { get; private set; }
        public DateTime CollectionDate { get; set; }
        public string Status { get; set; }
        public decimal TotalPrice { get; set; }

        public Order()
        {
            OrderDate = DateTime.Now;
            CollectionDate = OrderDate.Add(DefaultCollectionTimeOffset);
            Status = "Confirmed";

        }

        public Order(IEnumerable<MenuItem> items) : this()
        {
            Items = items.ToList();
            TotalPrice = (decimal)Items.Sum(item => item.Price * item.Quantity);
        }

        public Order(List<MenuItem> items, string orderNumber, string status, DateTime? collectionDate = null, decimal totalPrice = 0)
        {
            Items = items;
            OrderNumber = orderNumber;
            OrderDate = DateTime.Now;
            CollectionDate = collectionDate ?? OrderDate.Add(DefaultCollectionTimeOffset);
            TotalPrice = totalPrice != 0 ? totalPrice : (decimal)Items.Sum(item => item.Price * item.Quantity);
            Status = status;
        }

        public string GetNextOrderNumber(IEnumerable<Order> orderHistory)
        {
            int nextOrderNumber = orderHistory.Count() + 1;
            return nextOrderNumber.ToString("D4"); // Format as a 4-digit number
        }


    }
}
