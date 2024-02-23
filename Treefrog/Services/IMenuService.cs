//Handles generating the menu and allows for category selection to filter results.

using Treefrog.Models;
using MenuItem = Treefrog.Models.MenuItem;

namespace Treefrog.Services
{
    public interface IMenuService
    {
        IEnumerable<MenuItem> GetAllMenuItems();
        IEnumerable<MenuItem> GetMenuItemsByCategory(string category);
    }

    public class MenuService : IMenuService
    {
        private readonly Menu _menu;

        public MenuService(Menu menu)
        {
            _menu = menu;
        }

        public IEnumerable<MenuItem> GetAllMenuItems()
        {
            return _menu.GetMenuItems();
        }

        public IEnumerable<MenuItem> GetMenuItemsByCategory(string category)
        {
            return _menu.GetMenuItems()
                        .Where(item => item.Category.Equals(category, StringComparison.OrdinalIgnoreCase));
                        
        }
    }
}

