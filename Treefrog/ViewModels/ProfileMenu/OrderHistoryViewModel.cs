using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Treefrog.Services;
using Treefrog.Models; // Make sure to include this if MenuItem is within this namespace

namespace Treefrog.ViewModels
{
    public class OrderHistoryViewModel : BasePageViewModel
    {
        private readonly IOrderService _orderService;
        public ObservableCollection<Order> OrderHistory { get; } = new ObservableCollection<Order>();

        public OrderHistoryViewModel(IOrderService orderService, INavigationService navigationService) : base(navigationService)
        {
            _orderService = orderService;  
         LoadOrderHistory();
        }

        private void LoadOrderHistory()
        {
            var orderHistory = _orderService.GetOrderHistory();
            foreach (var order in orderHistory)
            {
                OrderHistory.Add(order);
            }
        }
    }

}

