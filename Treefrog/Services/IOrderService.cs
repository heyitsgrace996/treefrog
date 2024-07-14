// Handles generating the Order number and saving orders to OrderHistory List. Also stores current order for Order Confirmation process.

using Treefrog.Models;

public interface IOrderService
{
    void SaveOrder(Order order);
    Task<IEnumerable<Order>> GetOrderHistoryAsync();
    Order CurrentOrder { get; set; }
}

