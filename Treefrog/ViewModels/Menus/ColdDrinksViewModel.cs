using System.Collections.ObjectModel;
using Treefrog.Services;
using Treefrog.Models;
using System.Windows.Input;
using MenuItem = Treefrog.Models.MenuItem;

namespace Treefrog.ViewModels
{
    public class ColdDrinksViewModel : BasePageViewModel
    {
        //Generate Cold Drinks Menu
        public ObservableCollection<Models.MenuItem> ColdDrinks { get; private set; } = new ObservableCollection<Models.MenuItem>();

        //Services
        private readonly IMenuService _menuService;
        private readonly INavigationService _navigationService;
        private readonly IBasketService _basketService;

        //Add/Remove from basket
        public ICommand IncrementQuantityCommand { get; private set; }
        public ICommand DecrementQuantityCommand { get; private set; }

        //Total Price
        public decimal BasketTotalPrice => _basketService.GetTotalPrice();

        public ColdDrinksViewModel(INavigationService navigationService, IMenuService menuService, IBasketService basketService) : base(navigationService)
        {
            _menuService = menuService;
            _navigationService = navigationService;
            _basketService = basketService;

            LoadColdDrinks();

            IncrementQuantityCommand = new Command<MenuItem>(IncrementQuantity);
            DecrementQuantityCommand = new Command<MenuItem>(DecrementQuantity);

            _basketService.BasketUpdated += (s, e) => OnPropertyChanged(nameof(BasketTotalPrice));
        }

        //Load Menu
        private void LoadColdDrinks()
        {
            var coldDrinks = _menuService.GetMenuItemsByCategory("Cold Drinks");
            foreach (var item in coldDrinks)
            {
                ColdDrinks.Add(item);
            }
        }


        private void IncrementQuantity(MenuItem menuItem)
        {
            if (menuItem != null)
            {
                _basketService.ModifyItemQuantity(menuItem, 1);
                OnPropertyChanged(nameof(BasketTotalPrice));
            }
            else
            {
                // Handle the case where the menuItem is null
                Console.WriteLine("Error: Unable to increment quantity. MenuItem is null.");
            }
        }

        private void DecrementQuantity(MenuItem menuItem)
        {
            if (menuItem != null)
            {
                _basketService.ModifyItemQuantity(menuItem, -1);
                OnPropertyChanged(nameof(BasketTotalPrice));
            }
            else
            {
                // Handle the case where the menuItem is null
                Console.WriteLine("Error: Unable to decrement quantity. MenuItem is null.");
            }
        }
    }
}
