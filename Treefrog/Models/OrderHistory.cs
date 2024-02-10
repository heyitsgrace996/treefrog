using System;
namespace Treefrog.Models
{
    public class OrderHistory
    {
        public List<Order> DailyOrders { get; set; }

        public OrderHistory()
        {
            DailyOrders = new List<Order>();
        }

        // Method to add an order to the history
        public void AddOrder(Order order)
        {
            DailyOrders.Add(order);
        }

        // Optionally, methods to filter orders by date, customer, etc., can be added
    }

}

