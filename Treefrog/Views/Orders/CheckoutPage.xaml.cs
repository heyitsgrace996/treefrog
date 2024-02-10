using Treefrog.ViewModels;
using Treefrog.Services;

namespace Treefrog.Views;

public partial class CheckoutPage : ContentPage
{
    public CheckoutPage(INavigationService navigationService) 
    {

        InitializeComponent();
        BindingContext = new CheckoutViewModel(navigationService);
    }
}