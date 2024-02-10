using System;
namespace Treefrog.Models
{
    public class OrderItem
    {
        public string MenuItemId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; } // Price at the time of order in case it changes in the future

        public OrderItem(string menuItemId, int quantity, double price)
        {
            MenuItemId = menuItemId;
            Quantity = quantity;
            Price = price;
        }
    }

}

