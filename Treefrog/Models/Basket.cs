
using MenuItem = Treefrog.Models.MenuItem;

public class Basket
{
    private List<MenuItem> items = new List<MenuItem>();

    // Event to notify when the basket is updated
    public event EventHandler BasketUpdated;

    // Add/Remove/Update Item Quantity
    public void ModifyItemQuantity(MenuItem menuItem, int quantityChange)
    {
        var existingItem = items.FirstOrDefault(i => i.Id == menuItem.Id);

        if (existingItem != null)
        {
            // Update quantity of existing item
            existingItem.Quantity += quantityChange;

            // Remove item if quantity drops to zero or less
            if (existingItem.Quantity <= 0)
            {
                items.Remove(existingItem);
            }
        }
        else if (quantityChange > 0)
        {
            // Create a new instance of MenuItem to add to basket
            var newItem = new MenuItem(menuItem.Id, menuItem.Name, menuItem.Price, menuItem.Description, menuItem.Category);
            newItem.Quantity = quantityChange;
            items.Add(newItem);
        }

        // Notify basket update
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
