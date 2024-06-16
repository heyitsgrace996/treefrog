using System.Collections.ObjectModel;
using Treefrog.Services;
using Treefrog.Models;
using System.Windows.Input;
using MenuItem = Treefrog.Models.MenuItem;

namespace Treefrog.ViewModels
{
    public class HotDrinksViewModel : BasePageViewModel
    {
        //Load Menu
        public ObservableCollection<Models.MenuItem> HotDrinks { get; private set; } = new ObservableCollection<Models.MenuItem>();

        //Services
        private readonly IMenuService _menuService;
        private readonly INavigationService _navigationService;
        private readonly IBasketService _basketService;

        //Add/Remove items from basket
        public ICommand IncrementQuantityCommand { get; private set; }
        public ICommand DecrementQuantityCommand { get; private set; }
        
        // Info button command
        public ICommand ShowDescriptionCommand { get; private set; }
        public ICommand HideDescriptionCommand { get; private set; }
        
        // Popup properties
        private bool _isPopupVisible;
        private string _popupDescription;
        
        public bool IsPopupVisible
        {
            get => _isPopupVisible;
            set => SetProperty(ref _isPopupVisible, value);
        }

        public string PopupDescription
        {
            get => _popupDescription;
            set => SetProperty(ref _popupDescription, value);
        }


        public decimal BasketTotalPrice => _basketService.GetTotalPrice();

        public HotDrinksViewModel(INavigationService navigationService, IMenuService menuService, IBasketService basketService) : base(navigationService)
        {
            _menuService = menuService;
            _navigationService = navigationService;
            _basketService = basketService;

            LoadHotDrinks();

            IncrementQuantityCommand = new Command<MenuItem>(IncrementQuantity);
            DecrementQuantityCommand = new Command<MenuItem>(DecrementQuantity);
            
            ShowDescriptionCommand = new Command<MenuItem>(ShowDescription);
            HideDescriptionCommand = new Command(HideDescription);

            _basketService.BasketUpdated += (s, e) => OnPropertyChanged(nameof(BasketTotalPrice));
        }

        private void LoadHotDrinks()
        {
            var hotDrinks = _menuService.GetMenuItemsByCategory("Hot Drinks");
            foreach (var item in hotDrinks)
            {
                HotDrinks.Add(item);
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
        
        private void ShowDescription(MenuItem menuItem)
        {
            if (menuItem != null)
            {
                PopupDescription = menuItem.Description;
                IsPopupVisible = true;
            }
        }

        private void HideDescription()
        {
            IsPopupVisible = false;
            PopupDescription = string.Empty;
        }

    }
}
