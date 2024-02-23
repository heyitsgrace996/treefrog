
using MenuItem = Treefrog.Models.MenuItem;

public class Basket
{
    private List<MenuItem> items = new List<MenuItem>();

    // Event to notify when the basket is updated
    public event EventHandler BasketUpdated;

    // Add/Remove/Update Item Quantity
    public void ModifyItemQuantity(MenuItem menuItem, int quantityChange)
    {
        var item = items.FirstOrDefault(i => i.Id == menuItem.Id);
        if (item != null)
        {
            // Update quantity
            item.Quantity += quantityChange;

            // Remove Item
            if (item.Quantity <= 0)
            {
                items.Remove(item);
            }
        }
        else if (quantityChange > 0)
        {
            // Add new item
            menuItem.Quantity = quantityChange;
            items.Add(menuItem);
        }

        // Basket Update event logged
        BasketUpdated?.Invoke(this, EventArgs.Empty);
    }

    
    public IEnumerable<MenuItem> GetItems()
    {
        return items;
    }

    
    public decimal CalculateTotalPrice()
    {
        return items.Sum(item => (decimal)item.Price * item.Quantity);
    }

    
    public void Clear()
    {
        foreach (var item in items)
        {
            item.Quantity = 0;
        }
        items.Clear();
        BasketUpdated?.Invoke(this, EventArgs.Empty);
    }

}
