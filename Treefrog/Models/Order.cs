using System;
namespace Treefrog.Models
{
    public class Order
    {
        public string OrderId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public List<OrderItem> Items { get; set; }
        public DateTime OrderDate { get; set; }

        // Calculate total price based on item prices and quantities
        public double TotalPrice { get; set; } // This will be set externally after calculating

        public Order()
        {
            OrderId = Guid.NewGuid().ToString();
            Items = new List<OrderItem>();
            OrderDate = DateTime.Now;
        }
    }


}

