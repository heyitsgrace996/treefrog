using Treefrog.Services;
using Treefrog.ViewModels;

namespace Treefrog.Views
{
    public partial class OrderHistoryPage : ContentPage
    {
        

        public OrderHistoryPage(IOrderService orderService, INavigationService navigationService)
        {
            InitializeComponent();
            BindingContext = new OrderHistoryViewModel(orderService, navigationService);
            
        }

    }
}
