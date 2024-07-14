using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Treefrog.Models.Database;
using Treefrog.Services;
using Treefrog.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Treefrog.ViewModels;

namespace Treefrog.ViewModels
{
    public class OrderHistoryViewModel : BasePageViewModel
    {
        // Service to fetch order history
        private readonly IOrderService _orderService;

        // Collection to hold order history
        public ObservableCollection<DbOrder> OrderHistory { get; set; }

        // Property to hold the selected order
        private DbOrder _selectedOrder;
        public DbOrder SelectedOrder
        {
            get => _selectedOrder;
            set
            {
                Debug.WriteLine($"SelectedOrder set to {value?.OrderNumber}");
                SetProperty(ref _selectedOrder, value);
            }
        }

        // Property to control the visibility of the popup
        private bool _isPopupVisible;
        public bool IsPopupVisible
        {
            get => _isPopupVisible;
            set
            {
                Debug.WriteLine($"IsPopupVisible set to {value}");
                SetProperty(ref _isPopupVisible, value);
            }
        }

        // Commands for view receipt and close popup actions
        public ICommand ViewReceiptCommand { get; private set; }
        public ICommand ClosePopupCommand { get; private set; }

        // Constructor
        public OrderHistoryViewModel(IOrderService orderService, INavigationService navigationService) :base(navigationService)
        {
            _orderService = orderService;
            Debug.WriteLine("OrderHistoryViewModel initialized");

            LoadOrderHistoryAsync();
            ViewReceiptCommand = new RelayCommand<DbOrder>(ViewReceipt);
            ClosePopupCommand = new RelayCommand(ClosePopup);
        }

        // Method to load order history asynchronously
        private async Task LoadOrderHistory()
        {
            try
            {
                Debug.WriteLine("Loading order history...");
                var orderHistory = await _orderService.GetOrderHistoryAsync();

                // Convert the IEnumerable<Order> to ObservableCollection<DbOrder>
                var dbOrderHistory = orderHistory.Select(order => new DbOrder
                {
                    OrderNumber = order.OrderNumber,
                    OrderDate = order.OrderDate,
                    TotalPrice = order.TotalPrice
                }).ToList();

                OrderHistory = new ObservableCollection<DbOrder>(dbOrderHistory);
                Debug.WriteLine($"Order history loaded with {OrderHistory.Count} orders");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Failed to load order history: {ex.Message}");
            }
        }

        // Method to handle view receipt command
        private void ViewReceipt(DbOrder order)
        {
            Debug.WriteLine($"Viewing receipt for order {order.OrderNumber}");
            SelectedOrder = order;
            IsPopupVisible = true;
        }

        // Method to handle close popup command
        private void ClosePopup()
        {
            Debug.WriteLine("Closing popup");
            IsPopupVisible = false;
        }

        // Async initialization helper
        private async void LoadOrderHistoryAsync()
        {
            await LoadOrderHistory();
        }
    }
}