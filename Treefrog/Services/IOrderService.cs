// Handles generating the Order number and saving orders to OrderHistory List. Also stores current order for Order Confirmation process.

using Treefrog.Models;

public interface IOrderService
{
    void SaveOrder(Order order);
    IEnumerable<Order> GetOrderHistory();
    Order CurrentOrder { get; set; }
}

public class OrderService : IOrderService
{
    private List<Order> orders = new List<Order>();
    public Order CurrentOrder { get; set; }

    public void SaveOrder(Order order)
    {
        orders.Add(order);
    }

    public IEnumerable<Order> GetOrderHistory()
    {
        return orders.OrderBy(o => o.OrderNumber);
    }
}
