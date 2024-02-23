
using Treefrog.Services;
using Treefrog.ViewModels;
namespace Treefrog.Views;


public partial class BakeryPage : ContentPage
{
    public BakeryPage(INavigationService navigationService, IMenuService menuService, IBasketService basketService)
    {
        InitializeComponent();
        BindingContext = new BakeryViewModel(navigationService, menuService, basketService);
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is BasePageViewModel viewModel)
        {
            viewModel.IsPopupMenuVisible = false;

        }
    }

}



