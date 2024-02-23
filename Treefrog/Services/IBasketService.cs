// Handles adding and removing MenuItems from the Basket

using MenuItem = Treefrog.Models.MenuItem;

public interface IBasketService
{
    void ModifyItemQuantity(MenuItem menuItem, int quantityChange);
    IEnumerable<MenuItem> GetBasketItems();
    void ClearBasket();
    decimal GetTotalPrice();
    decimal GetItemPrice(int itemId);
    int GetQuantityForItem(int itemId);
    event EventHandler BasketUpdated;
}


public class BasketService : IBasketService
{
    private Basket basket = new Basket();

    public event EventHandler BasketUpdated;

    public BasketService()
    {
        // Basket update event
        basket.BasketUpdated += (sender, e) => OnBasketUpdated();
    }

    public void ModifyItemQuantity(MenuItem menuItem, int quantityChange)
    {
        basket.ModifyItemQuantity(menuItem, quantityChange);
    }

    public IEnumerable<MenuItem> GetBasketItems()
    {
        return basket.GetItems();
    }

    public void ClearBasket()
    {
        basket.Clear();
    }

    public decimal GetTotalPrice()
    {
        return basket.CalculateTotalPrice();
    }

    public decimal GetItemPrice(int itemId) //Returns total price per item (price*quantity)
    {
        var item = basket.GetItems().FirstOrDefault(i => i.Id == itemId);
        return item != null ? (decimal)item.Price * item.Quantity : 0M;
    }

    public int GetQuantityForItem(int itemId)
    {
        var item = basket.GetItems().FirstOrDefault(i => i.Id == itemId);
        return item?.Quantity ?? 0; // Return item quantity if exists, else return 0
    }

    protected virtual void OnBasketUpdated()
    {
        BasketUpdated?.Invoke(this, EventArgs.Empty);
    }
}