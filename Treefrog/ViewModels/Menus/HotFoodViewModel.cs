﻿using System.Collections.ObjectModel;
using Treefrog.Services;
using Treefrog.Models;
using System.Windows.Input;
using MenuItem = Treefrog.Models.MenuItem;

namespace Treefrog.ViewModels
{
    public class HotFoodViewModel : BasePageViewModel
    {
        //Load Menu
        public ObservableCollection<Models.MenuItem> HotFood { get; private set; } = new ObservableCollection<Models.MenuItem>();

        //Services
        private readonly IMenuService _menuService;
        private readonly INavigationService _navigationService;
        private readonly IBasketService _basketService;
       
        // Add/Remove items from Basket
        public ICommand IncrementQuantityCommand { get; private set; }
        public ICommand DecrementQuantityCommand { get; private set; }

        public decimal BasketTotalPrice => _basketService.GetTotalPrice();

        public HotFoodViewModel(INavigationService navigationService, IMenuService menuService, IBasketService basketService) : base(navigationService)
        {
            _menuService = menuService;
            _navigationService = navigationService;
            _basketService = basketService;

            LoadHotFood();

            IncrementQuantityCommand = new Command<MenuItem>(IncrementQuantity);
            DecrementQuantityCommand = new Command<MenuItem>(DecrementQuantity);

            _basketService.BasketUpdated += (s, e) => OnPropertyChanged(nameof(BasketTotalPrice));
        }

        private void LoadHotFood()
        {
            var hotFood = _menuService.GetMenuItemsByCategory("Hot Food");
            foreach (var item in hotFood)
            {
                HotFood.Add(item);
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
