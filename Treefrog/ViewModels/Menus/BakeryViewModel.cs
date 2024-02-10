using System.Collections.ObjectModel;
using Treefrog.Services;
using Treefrog.Models;

namespace Treefrog.ViewModels
{
    public class BakeryViewModel : BasePageViewModel
    {
        public ObservableCollection<Models.MenuItem> Bakery { get; private set; } = new ObservableCollection<Models.MenuItem>();
        private readonly IMenuService _menuService;
        private readonly INavigationService _navigationService;

        public BakeryViewModel(INavigationService navigationService, IMenuService menuService) : base(navigationService)
        {
            _menuService = menuService;
            _navigationService = navigationService;
            LoadBakery();
        }

        private void LoadBakery()
        {
            var bakery = _menuService.GetMenuItemsByCategory("Bakery");
            foreach (var item in bakery)
            {
                bakery.Add(item);
            }
        }
    }
}