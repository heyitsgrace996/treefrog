
using Treefrog.Services;
using Treefrog.ViewModels;
namespace Treefrog.Views;


public partial class ColdDrinksPage : ContentPage
{
    public ColdDrinksPage(INavigationService navigationService, IMenuService menuService, IBasketService basketService)
    {
        InitializeComponent();
        BindingContext = new ColdDrinksViewModel(navigationService, menuService, basketService);
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



