using Treefrog.ViewModels;
using Treefrog.Services;

namespace Treefrog.Views;

public partial class ContactPage : ContentPage
{
    public ContactPage(INavigationService navigationService)
    {

        InitializeComponent();
        BindingContext = new BasePageViewModel(navigationService);
    }
}