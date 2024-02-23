using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Treefrog.Models;
using Treefrog.Services;

namespace Treefrog.ViewModels
{
    public class CheckoutViewModel : BasePageViewModel
    {
        private readonly ProfileViewModel _profileViewModel;
        private readonly INavigationService _navigationService;
        private readonly IBasketService _basketService;
        private readonly IOrderService _orderService;

        private Order _currentOrder;
        public ICommand PlaceOrderCommand { get; private set; }

        
        public Order CurrentOrder
        {
            get => _currentOrder;
            set
            {
                _currentOrder = value;
                OnPropertyChanged(nameof(CurrentOrder));
            }
        }

        
        public DateTime? CollectionDate => CurrentOrder?.CollectionDate;
        public decimal? TotalPrice => CurrentOrder?.TotalPrice;

        public string UserName => _profileViewModel.UserName;
        public string UserEmail => _profileViewModel.UserEmail;
        public string UserPhone => _profileViewModel.UserPhone;


        public CheckoutViewModel(
    ProfileViewModel profileViewModel,
    INavigationService navigationService,
    IBasketService basketService,
    IOrderService orderService)
    : base(navigationService)
        {
            _profileViewModel = profileViewModel;
            _navigationService = navigationService;
            _basketService = basketService;
            _orderService = orderService;

            Debug.WriteLine("TEST");
            _currentOrder = _orderService.CurrentOrder;

            if (_currentOrder != null)
            {
                Debug.WriteLine($"CurrentOrder after navigation: OrderNumber={_currentOrder.OrderNumber}, TotalPrice={_currentOrder.TotalPrice}, ItemsCount={_currentOrder.Items?.Count ?? 0}");
            }
            else
            {
                Debug.WriteLine("CurrentOrder after navigation: null");
            }

            PlaceOrderCommand = new Command(PlaceOrder);
        }


        private void PlaceOrder()
        {
            if (_currentOrder == null)
            {
                Debug.WriteLine("No order to place");
                return;
            }


            Debug.WriteLine("PlaceOrder started");

            // Assign the OrderNumber and saves the order
            _orderService.SaveOrder(_currentOrder);

            Debug.WriteLine($"Order placed with OrderNumber: {_currentOrder.OrderNumber}");
            MessagingCenter.Send(this, "OrderPlaced");

            Debug.WriteLine("Order saved");

            ResetViewModel();

            Debug.WriteLine("Checkout reset");

            NavigateToOrderConfCommand.Execute(null);
            Debug.WriteLine("Navigating to Order Confirmation Page");
        }


        public void ResetViewModel()
        {
            Debug.WriteLine("Resetting order and basket...");

            // Empty the basket
            _basketService.ClearBasket();
            Debug.WriteLine("Basket cleared.");

            // Dispose of the CurrentOrder object
            _orderService.CurrentOrder = null;
            Debug.WriteLine("Current order disposed.");

            // Notify object change
            OnPropertyChanged(nameof(CurrentOrder));
            OnPropertyChanged(nameof(CollectionDate));
            OnPropertyChanged(nameof(TotalPrice));
        }


        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
        }
    }
}
