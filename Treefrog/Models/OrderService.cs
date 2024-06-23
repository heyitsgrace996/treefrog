namespace Treefrog.Models;

public class OrderService
{
    public Basket CurrentBasket { get; private set; } = new Basket();
    private List<Order> orderHistory = new List<Order>();

    public void AddToBasket(BasketItem item)
    {
        CurrentBasket.AddItem(item);
    }

    public Order PlaceOrder()
    {
        var order = new Order
        {
            OrderId = orderHistory.Count + 1,
            OrderDate = DateTime.Now,
            Items = new List<BasketItem>(CurrentBasket.Items),
            TotalPrice = CurrentBasket.TotalPrice
        };

        orderHistory.Add(order);
        CurrentBasket.ClearBasket();

        return order;
    }

    public List<Order> GetOrderHistory()
    {
        return orderHistory;
    }
}
