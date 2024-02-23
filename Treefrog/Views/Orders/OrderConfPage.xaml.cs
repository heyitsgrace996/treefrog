using Treefrog.ViewModels;
using Treefrog.Services;

namespace Treefrog.Views;


public partial class OrderConfPage : ContentPage
{
    public OrderConfPage(INavigationService navigationService)
    {
        InitializeComponent();
        BindingContext = new OrderConfViewModel(navigationService);
    }
}
