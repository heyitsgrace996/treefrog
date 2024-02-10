using System;
using Treefrog.Models;
using MenuItem = Treefrog.Models.MenuItem;

namespace Treefrog.Services
{
    public interface IMenuService
    {
        List<MenuItem> GetAllMenuItems();
        List<MenuItem> GetMenuItemsByCategory(string category);
    }

    public class MenuService : IMenuService
    {
        private List<MenuItem> _menuItems;

        public MenuService()
        {
            _menuItems = new List<MenuItem>();
            InitializeMenuItems(); // Populate the _menuItems list
        }

        public List<MenuItem> GetAllMenuItems()
        {
            return _menuItems;
        }

        public List<MenuItem> GetMenuItemsByCategory(string category)
        {
            return _menuItems.Where(item => item.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        private void InitializeMenuItems()
        {
            _menuItems.Add(new MenuItem("Ham & Cheese Sandwich", 4.99, "Classic sandwich with ham, cheese, lettuce, and tomato.", "Hot Food"));
            _menuItems.Add(new MenuItem("Turkey Club Wrap", 5.99, "Tortilla wrap filled with turkey, bacon, lettuce, tomato, and mayo.", "Hot Food"));
            _menuItems.Add(new MenuItem("Grilled Cheese & Tomato Soup Combo", 6.99, "Buttery grilled cheese sandwich served with a side of creamy tomato soup.", "Hot Food"));
            _menuItems.Add(new MenuItem("BLT Baguette", 4.49, "Baguette filled with crispy bacon, lettuce, tomato, and mayo.", "Hot Food"));
            _menuItems.Add(new MenuItem("Chicken Caesar Salad", 7.99, "Fresh romaine lettuce topped with grilled chicken, croutons, Parmesan cheese, and Caesar dressing.", "Hot Food"));
            _menuItems.Add(new MenuItem("Vegetarian Quiche", 5.49, "Savory quiche filled with vegetables and cheese, served with a side salad.", "Hot Food"));
            _menuItems.Add(new MenuItem("Sausage Roll", 3.49, "Flaky pastry filled with seasoned sausage meat, perfect for a quick bite.", "Hot Food"));
            _menuItems.Add(new MenuItem("Vegetable Panini", 6.49, "Pressed sandwich with roasted vegetables, pesto, and mozzarella cheese.", "Hot Food"));

            _menuItems.Add(new MenuItem("Croissant", 2.49, "Buttery and flaky pastry, perfect for breakfast or a snack.", "Bakery"));
            _menuItems.Add(new MenuItem("Chocolate Chip Cookie", 1.99, "Classic homemade cookie loaded with chocolate chips.", "Bakery"));
            _menuItems.Add(new MenuItem("Blueberry Muffin", 2.99, "Moist muffin bursting with juicy blueberries.", "Bakery"));
            _menuItems.Add(new MenuItem("Cinnamon Roll", 3.49, "Soft and gooey cinnamon pastry drizzled with sweet icing.", "Bakery"));
            _menuItems.Add(new MenuItem("Baguette", 2.99, "Crispy French bread with a soft interior, ideal for sandwiches or dipping.", "Bakery"));
            _menuItems.Add(new MenuItem("Apple Pie Slice", 4.99, "Warm apple pie filling encased in a flaky pastry crust.", "Bakery"));
            _menuItems.Add(new MenuItem("Sourdough Bread", 3.99, "Rustic loaf with a tangy flavor and chewy crust.", "Bakery"));
            _menuItems.Add(new MenuItem("Almond Croissant", 3.49, "Croissant filled with almond paste and topped with sliced almonds.", "Bakery"));

            _menuItems.Add(new MenuItem("Iced Tea", 2.49, "Refreshing black tea served over ice, with lemon if desired.", "Cold Drinks"));
            _menuItems.Add(new MenuItem("Lemonade", 2.99, "Tangy and sweet lemon-flavored drink, perfect for quenching thirst.", "Cold Drinks"));
            _menuItems.Add(new MenuItem("Smoothie (Mixed Berry)", 4.99, "Blend of strawberries, blueberries, raspberries, and yogurt for a refreshing treat.", "Cold Drinks"));
            _menuItems.Add(new MenuItem("Soda (Coke, Pepsi, Sprite, etc.)", 1.99, "Classic carbonated beverages available in various flavors.", "Cold Drinks"));
            _menuItems.Add(new MenuItem("Iced Latte", 3.99, "Espresso mixed with cold milk and served over ice.", "Cold Drinks"));
            _menuItems.Add(new MenuItem("Milkshake (Chocolate, Vanilla, Strawberry)", 4.49, "Creamy blend of milk and flavored syrup, topped with whipped cream.", "Cold Drinks"));
            _menuItems.Add(new MenuItem("Fresh Orange Juice", 3.49, "Squeezed from ripe oranges for a vitamin-packed drink.", "Cold Drinks"));
            _menuItems.Add(new MenuItem("Cold Brew Coffee", 3.99, "Smooth and bold coffee brewed cold for a refreshing pick-me-up.", "Cold Drinks"));

            _menuItems.Add(new MenuItem("Cappuccino", 3.49, "Espresso topped with frothy steamed milk and a sprinkle of cocoa.", "Hot Drinks"));
            _menuItems.Add(new MenuItem("Hot Chocolate", 3.99, "Rich and creamy chocolate drink topped with whipped cream and chocolate shavings.", "Hot Drinks"));
            _menuItems.Add(new MenuItem("Chai Latte", 4.49, "Spiced black tea blended with steamed milk and honey.", "Hot Drinks"));
            _menuItems.Add(new MenuItem("Green Tea", 2.99, "Fragrant and soothing tea made from green tea leaves.", "Hot Drinks"));
            _menuItems.Add(new MenuItem("Mocha", 4.49, "Espresso combined with chocolate syrup and steamed milk, topped with whipped cream.", "Hot Drinks"));
            _menuItems.Add(new MenuItem("Herbal Tea (Peppermint, Chamomile, etc.)", 2.99, "Calming and aromatic herbal infusion, perfect for relaxation.", "Hot Drinks"));
            _menuItems.Add(new MenuItem("Americano", 2.99, "Espresso diluted with hot water, for a strong and smooth coffee flavor.", "Hot Drinks"));
            _menuItems.Add(new MenuItem("Irish Coffee", 5.99, "Hot coffee spiked with Irish whiskey and topped with whipped cream.", "Hot Drinks"));
        }
    }

}

