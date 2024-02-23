namespace Treefrog.Models
{
    public class Menu
    {
        public List<MenuItem> _menuItems { get; set; }

        public Menu()
        {
            _menuItems = new List<MenuItem>();
            InitializeMenuItems();
        }

        public IEnumerable<MenuItem> GetMenuItems() => _menuItems.AsReadOnly();

        private void InitializeMenuItems()
        {
            int id = 1; // Starting ID
            _menuItems.Add(new MenuItem(id++, "Ham & Cheese Sandwich", 4.99, "Classic sandwich with ham, cheese, lettuce, and tomato.", "Hot Food"));
            _menuItems.Add(new MenuItem(id++, "Turkey Club Wrap", 5.99, "Tortilla wrap filled with turkey, bacon, lettuce, tomato, and mayo.", "Hot Food"));
            _menuItems.Add(new MenuItem(id++, "Grilled Cheese & Tomato Soup Combo", 6.99, "Buttery grilled cheese sandwich served with a side of creamy tomato soup.", "Hot Food"));
            _menuItems.Add(new MenuItem(id++, "BLT Baguette", 4.49, "Baguette filled with crispy bacon, lettuce, tomato, and mayo.", "Hot Food"));
            _menuItems.Add(new MenuItem(id++, "Chicken Caesar Salad", 7.99, "Fresh romaine lettuce topped with grilled chicken, croutons, Parmesan cheese, and Caesar dressing.", "Hot Food"));
            _menuItems.Add(new MenuItem(id++, "Vegetarian Quiche", 5.49, "Savory quiche filled with vegetables and cheese, served with a side salad.", "Hot Food"));
            _menuItems.Add(new MenuItem(id++, "Sausage Roll", 3.49, "Flaky pastry filled with seasoned sausage meat, perfect for a quick bite.", "Hot Food"));
            _menuItems.Add(new MenuItem(id++, "Vegetable Panini", 6.49, "Pressed sandwich with roasted vegetables, pesto, and mozzarella cheese.", "Hot Food"));

            _menuItems.Add(new MenuItem(id++, "Croissant", 2.49, "Buttery and flaky pastry, perfect for breakfast or a snack.", "Bakery"));
            _menuItems.Add(new MenuItem(id++, "Chocolate Chip Cookie", 1.99, "Classic homemade cookie loaded with chocolate chips.", "Bakery"));
            _menuItems.Add(new MenuItem(id++, "Blueberry Muffin", 2.99, "Moist muffin bursting with juicy blueberries.", "Bakery"));
            _menuItems.Add(new MenuItem(id++, "Cinnamon Roll", 3.49, "Soft and gooey cinnamon pastry drizzled with sweet icing.", "Bakery"));
            _menuItems.Add(new MenuItem(id++, "Baguette", 2.99, "Crispy French bread with a soft interior, ideal for sandwiches or dipping.", "Bakery"));
            _menuItems.Add(new MenuItem(id++, "Apple Pie Slice", 4.99, "Warm apple pie filling encased in a flaky pastry crust.", "Bakery"));
            _menuItems.Add(new MenuItem(id++, "Sourdough Bread", 3.99, "Rustic loaf with a tangy flavor and chewy crust.", "Bakery"));
            _menuItems.Add(new MenuItem(id++, "Almond Croissant", 3.49, "Croissant filled with almond paste and topped with sliced almonds.", "Bakery"));

            _menuItems.Add(new MenuItem(id++, "Iced Tea", 2.49, "Refreshing black tea served over ice, with lemon if desired.", "Cold Drinks"));
            _menuItems.Add(new MenuItem(id++, "Lemonade", 2.99, "Tangy and sweet lemon-flavored drink, perfect for quenching thirst.", "Cold Drinks"));
            _menuItems.Add(new MenuItem(id++, "Smoothie (Mixed Berry)", 4.99, "Blend of strawberries, blueberries, raspberries, and yogurt for a refreshing treat.", "Cold Drinks"));
            _menuItems.Add(new MenuItem(id++, "Soda (Coke, Pepsi, Sprite, etc.)", 1.99, "Classic carbonated beverages available in various flavors.", "Cold Drinks"));
            _menuItems.Add(new MenuItem(id++, "Iced Latte", 3.99, "Espresso mixed with cold milk and served over ice.", "Cold Drinks"));
            _menuItems.Add(new MenuItem(id++, "Milkshake (Chocolate, Vanilla, Strawberry)", 4.49, "Creamy blend of milk and flavored syrup, topped with whipped cream.", "Cold Drinks"));
            _menuItems.Add(new MenuItem(id++, "Fresh Orange Juice", 3.49, "Squeezed from ripe oranges for a vitamin-packed drink.", "Cold Drinks"));
            _menuItems.Add(new MenuItem(id++, "Cold Brew Coffee", 3.99, "Smooth and bold coffee brewed cold for a refreshing pick-me-up.", "Cold Drinks"));

            _menuItems.Add(new MenuItem(id++, "Cappuccino", 3.49, "Espresso topped with frothy steamed milk and a sprinkle of cocoa.", "Hot Drinks"));
            _menuItems.Add(new MenuItem(id++, "Hot Chocolate", 3.99, "Rich and creamy chocolate drink topped with whipped cream and chocolate shavings.", "Hot Drinks"));
            _menuItems.Add(new MenuItem(id++, "Chai Latte", 4.49, "Spiced black tea blended with steamed milk and honey.", "Hot Drinks"));
            _menuItems.Add(new MenuItem(id++, "Green Tea", 2.99, "Fragrant and soothing tea made from green tea leaves.", "Hot Drinks"));
            _menuItems.Add(new MenuItem(id++, "Mocha", 4.49, "Espresso combined with chocolate syrup and steamed milk, topped with whipped cream.", "Hot Drinks"));
            _menuItems.Add(new MenuItem(id++, "Herbal Tea (Peppermint, Chamomile, etc.)", 2.99, "Calming and aromatic herbal infusion, perfect for relaxation.", "Hot Drinks"));
            _menuItems.Add(new MenuItem(id++, "Americano", 2.99, "Espresso diluted with hot water, for a strong and smooth coffee flavor.", "Hot Drinks"));
            _menuItems.Add(new MenuItem(id++, "Irish Coffee", 5.99, "Hot coffee spiked with Irish whiskey and topped with whipped cream.", "Hot Drinks"));
        }

        public void AddMenuItem(MenuItem menuItem)
        {
            _menuItems.Add(menuItem);
        }
    }
}
