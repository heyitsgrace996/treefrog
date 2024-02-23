
using Treefrog.Services;
using Treefrog.ViewModels;
namespace Treefrog.Views;


public partial class HotDrinksPage : ContentPage
{
    public HotDrinksPage(INavigationService navigationService, IMenuService menuService, IBasketService basketService)
    {
        InitializeComponent();
        BindingContext = new HotDrinksViewModel(navigationService, menuService, basketService);
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



