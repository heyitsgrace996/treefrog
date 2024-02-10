using Treefrog.ViewModels;
using Treefrog.Services;

namespace Treefrog.Views;

public partial class BasketPage : ContentPage
{
    public BasketPage(INavigationService navigationService) 
    {

        InitializeComponent();
        BindingContext = new BasketPage(navigationService);
    }
}