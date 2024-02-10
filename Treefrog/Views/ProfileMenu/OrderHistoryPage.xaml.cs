using Treefrog.ViewModels;
using Treefrog.Services;

namespace Treefrog.Views;

public partial class OrderHistoryPage : ContentPage
{
    public OrderHistoryPage(INavigationService navigationService)
    {

        InitializeComponent();
        BindingContext = new OrderHistoryViewModel(navigationService);
    }
}