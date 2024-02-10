using System.Collections.ObjectModel;
using Treefrog.Services;
using Treefrog.Models;

namespace Treefrog.ViewModels
{
    public class HotDrinksViewModel : BasePageViewModel
    {
        public ObservableCollection<Models.MenuItem> HotDrinks { get; private set; } = new ObservableCollection<Models.MenuItem>();
        private readonly IMenuService _menuService;
        private readonly INavigationService _navigationService;

        public HotDrinksViewModel(INavigationService navigationService, IMenuService menuService) : base(navigationService)
        {
            _menuService = menuService;
            _navigationService = navigationService;
            LoadHotDrinks();
        }

        private void LoadHotDrinks()
        {
            var hotDrinks = _menuService.GetMenuItemsByCategory("Hot Drinks");
            foreach (var item in hotDrinks)
            {
                HotDrinks.Add(item);
            }
        }
    }
}