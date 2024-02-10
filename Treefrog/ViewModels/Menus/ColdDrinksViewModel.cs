using System.Collections.ObjectModel;
using Treefrog.Services;
using Treefrog.Models;

namespace Treefrog.ViewModels
{
    public class ColdDrinksViewModel : BasePageViewModel
    {
        public ObservableCollection<Models.MenuItem> ColdDrinks { get; private set; } = new ObservableCollection<Models.MenuItem>();
        private readonly IMenuService _menuService;
        private readonly INavigationService _navigationService;

        public ColdDrinksViewModel(INavigationService navigationService, IMenuService menuService) : base(navigationService)
        {
            _menuService = menuService;
            _navigationService = navigationService;
            LoadColdDrinks();
        }

        private void LoadColdDrinks()
        {
            var coldDrinks = _menuService.GetMenuItemsByCategory("Cold Drinks");
            foreach (var item in coldDrinks)
            {
                coldDrinks.Add(item);
            }
        }
    }
}