using System;
namespace Treefrog.Models
{
    public class Menu
    {
        public List<MenuItem> MenuItems { get; set; }

        public Menu()
        {
            MenuItems = new List<MenuItem>();
        }

        public void AddMenuItem(MenuItem menuItem)
        {
            MenuItems.Add(menuItem);
        }

        public void PopulateMenu()
        {
            // Adding different types of menu items
            AddMenuItem(new MenuItem("Espresso", 2.5, "Strong and bold espresso.", "Hot Drink"));
            AddMenuItem(new MenuItem("Iced Coffee", 2.0, "Refreshing cold brew.", "Cold Drink"));
            AddMenuItem(new MenuItem("Pizza Slice", 3.0, "Hot and delicious slice of pizza.", "Hot Food"));
            AddMenuItem(new MenuItem("Croissant", 2.5, "Buttery and flaky French pastry.", "Bakery"));
        }
    }

}
