using Treefrog.ViewModels;
using Treefrog.Services;

namespace Treefrog.Views;

public partial class BasketPage : ContentPage
{
    public BasketPage(INavigationService navigationService, IBasketService basketService, IOrderService orderService) 
    {

        InitializeComponent();
        BindingContext = new BasketViewModel(navigationService, basketService, orderService);
    }
}