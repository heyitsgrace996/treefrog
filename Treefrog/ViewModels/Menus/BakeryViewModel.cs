using System.Collections.ObjectModel;
using Treefrog.Services;
using System.Windows.Input;
using MenuItem = Treefrog.Models.MenuItem;

namespace Treefrog.ViewModels
{
    public class BakeryViewModel : BasePageViewModel
    {
        //Generate the Bakery Menu
        public ObservableCollection<Models.MenuItem> Bakery { get; private set; } = new ObservableCollection<Models.MenuItem>();

        //Services
        private readonly IMenuService _menuService;
        private readonly INavigationService _navigationService;
        private readonly IBasketService _basketService;

        // +/- buttons for add to cart functionality
        public ICommand IncrementQuantityCommand { get; private set; }
        public ICommand DecrementQuantityCommand { get; private set; }

        // Total Price for Basket
        public decimal BasketTotalPrice => _basketService.GetTotalPrice();

        public BakeryViewModel(INavigationService navigationService, IMenuService menuService, IBasketService basketService) : base(navigationService)
        {
            _menuService = menuService;
            _navigationService = navigationService;
            _basketService = basketService;

            LoadBakery();

            IncrementQuantityCommand = new Command<MenuItem>(IncrementQuantity);
            DecrementQuantityCommand = new Command<MenuItem>(DecrementQuantity);

            _basketService.BasketUpdated += (s, e) => OnPropertyChanged(nameof(BasketTotalPrice));
        }

        //Load the menu
        private void LoadBakery()
        {
            var bakery = _menuService.GetMenuItemsByCategory("Bakery");
            foreach (var item in bakery)
            {
                Bakery.Add(item);
            }
        }


        private void IncrementQuantity(MenuItem menuItem)
        {
            if (menuItem != null)
            {
                _basketService.ModifyItemQuantity(menuItem, 1);
                OnPropertyChanged(nameof(BasketTotalPrice)); //Update Basket price after item added
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
                OnPropertyChanged(nameof(BasketTotalPrice)); //Update basket price after item removed
            }
            else
            {
                // Handle the case where the menuItem is null
                Console.WriteLine("Error: Unable to decrement quantity. MenuItem is null.");
            }
        }
    }
}
