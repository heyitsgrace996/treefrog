using System.Collections.ObjectModel;
using Treefrog.Services;
using Treefrog.Models;

namespace Treefrog.ViewModels
{
    public class HotFoodViewModel : BasePageViewModel
    {
        public ObservableCollection<Models.MenuItem> HotFood { get; private set; } = new ObservableCollection<Models.MenuItem>();
        private readonly IMenuService _menuService;
        private readonly INavigationService _navigationService;

        public HotFoodViewModel(INavigationService navigationService, IMenuService menuService) : base(navigationService)
        {
            _menuService = menuService;
            _navigationService = navigationService;
            LoadHotFood();
        }

        private void LoadHotFood()
        {
            var hotFood = _menuService.GetMenuItemsByCategory("Hot Food");
            foreach (var item in hotFood)
            {
                HotFood.Add(item);
            }
        }
    }
}
