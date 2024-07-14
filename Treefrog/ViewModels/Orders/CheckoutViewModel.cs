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
                OnPropertyChanged(nameof(OrderNumber));
                OnPropertyChanged(nameof(CollectionDate));
                OnPropertyChanged(nameof(TotalPrice));
            }
        }
        
        public string OrderNumber => CurrentOrder?.OrderNumber;

        
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
            Debug.WriteLine("CheckoutViewModel constructor called");
            
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
            
            LoadCurrentOrder();
            
            Debug.WriteLine("CheckoutViewModel initialization complete");
        }
        
        private void LoadCurrentOrder()
        {
            if (_orderService.CurrentOrder == null)
            {
                _orderService.CurrentOrder = new Order(_basketService.GetBasketItems());
            }
            
            CurrentOrder = _orderService.CurrentOrder;

            if (CurrentOrder != null)
            {
                Debug.WriteLine($"CurrentOrder loaded: OrderNumber={CurrentOrder.OrderNumber}, TotalPrice={CurrentOrder.TotalPrice}, ItemsCount={CurrentOrder.Items?.Count ?? 0}");
            }
            else
            {
                Debug.WriteLine("CurrentOrder loaded: null");
            }
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
            // Clear the basket after successful checkout
            ClearBasket();

            Debug.WriteLine("Checkout reset");
            
            // Notify menu items to reset quantities
            MessagingCenter.Send(this, "ResetMenuItems");

            NavigateToOrderConfCommand.Execute(null);
            Debug.WriteLine("Navigating to Order Confirmation Page");
        }


        public void ResetViewModel()
        {
            Debug.WriteLine("Resetting order and basket...");

            // Capture the call stack
            var stackTrace = new StackTrace();
            Debug.WriteLine(stackTrace.ToString());

            // Empty the basket
            _basketService.ClearBasket();
            Debug.WriteLine("Basket cleared.");

            // Dispose of the CurrentOrder object
            _orderService.CurrentOrder = new Order(); // Reset to a new order instead of null
            CurrentOrder = _orderService.CurrentOrder;
            Debug.WriteLine("Current order reset.");

            // Notify object change
            OnPropertyChanged(nameof(CurrentOrder));
            OnPropertyChanged(nameof(CollectionDate));
            OnPropertyChanged(nameof(TotalPrice));
        }
        
        private void ClearBasket()
        {
            _basketService.ClearBasket();
            //LoadBasketItems();
            OnPropertyChanged(nameof(TotalPrice));
            Debug.WriteLine("Basket cleared after checkout.");
        }


        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
        }
    }
}
