
using System.Collections.ObjectModel;
using Treefrog.Services;
using Treefrog.Models;
using MenuItem = Treefrog.Models.MenuItem;
using System.Windows.Input;
using System.Diagnostics;

namespace Treefrog.ViewModels
{
    public class BasketViewModel : BasePageViewModel
    {
        private readonly IOrderService _orderService;
        private readonly IBasketService _basketService;

        public ICommand GoToCheckoutCommand { get; private set; }

        public ObservableCollection<MenuItem> BasketItems { get; } = new ObservableCollection<MenuItem>();

        public decimal TotalPrice => _basketService.GetTotalPrice();

        public BasketViewModel(INavigationService navigationService, IBasketService basketService, IOrderService orderService)
            : base(navigationService)
        {
            _orderService = orderService;
            _basketService = basketService;
            _basketService.BasketUpdated += BasketUpdatedHandler;
            LoadBasketItems();

            GoToCheckoutCommand = new Command(async () => GoToCheckout());
        }

        private void BasketUpdatedHandler(object sender, EventArgs e)
        {
            // Reload basket items when the basket is updated
            LoadBasketItems();
            OnPropertyChanged(nameof(TotalPrice)); // Also update total price
        }

        private void LoadBasketItems()
        {
            BasketItems.Clear(); // refresh the list
            foreach (var item in _basketService.GetBasketItems())
            {
                BasketItems.Add(item);
            }
            OnPropertyChanged(nameof(BasketItems));
        }

        private void GoToCheckout()
        {
            Debug.WriteLine("Attempting to go to checkout...");

            if (BasketItems == null || !BasketItems.Any())
            {
                Debug.WriteLine("No items in the basket to checkout.");
                return;
            }

            Order newOrder = new Order
            {
                Items = new List<MenuItem>(BasketItems),
                TotalPrice = TotalPrice,
                Status = "Confirmed"
            };

            if (newOrder == null || newOrder.Items == null || !newOrder.Items.Any())
            {
                Debug.WriteLine("Failed to create a valid order.");
                return;
            }

            Debug.WriteLine($"Order created with TotalPrice: {newOrder.TotalPrice} and Items Count: {newOrder.Items.Count}");

            _orderService.CurrentOrder = newOrder;
            OnPropertyChanged(nameof(_orderService.CurrentOrder));

            // Checking null after setting
            if (_orderService.CurrentOrder == null)
            {
                Debug.WriteLine("Failed to set the CurrentOrder in the order service.");
                return;
            }

            Debug.WriteLine($"CurrentOrder before navigation: {(_orderService.CurrentOrder != null ? "Order Set" : "Null")}");

            try
            {
                NavigateToCheckoutCommand.Execute(null);
                Debug.WriteLine("Navigation to checkout page initiated successfully.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Failed to navigate to checkout: {ex.Message}");
            }

            // Optionally, re-check CurrentOrder after attempting navigation
            Debug.WriteLine($"CurrentOrder after attempting navigation: {(_orderService.CurrentOrder != null ? "Order Set" : "Null")}");
        }





        // Methods to handle item quantity changes if needed
        public void IncrementItemQuantity(MenuItem menuItem)
        {
            _basketService.ModifyItemQuantity(menuItem, 1);
            
        }

        public void DecrementItemQuantity(MenuItem menuItem)
        {
            _basketService.ModifyItemQuantity(menuItem, -1);
            
        }

    }
}

