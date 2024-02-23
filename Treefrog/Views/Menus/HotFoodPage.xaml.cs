
using Treefrog.Services;
using Treefrog.ViewModels;
namespace Treefrog.Views;


public partial class HotFoodPage : ContentPage
{
    public HotFoodPage(INavigationService navigationService, IMenuService menuService, IBasketService basketService)
    {
        InitializeComponent();
        BindingContext = new HotFoodViewModel(navigationService, menuService, basketService);
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



