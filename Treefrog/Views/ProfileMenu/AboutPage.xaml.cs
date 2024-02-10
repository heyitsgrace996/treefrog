using Treefrog.ViewModels;
using Treefrog.Services;

namespace Treefrog.Views;

public partial class AboutPage : ContentPage
{
    public AboutPage(INavigationService navigationService) 
    {

        InitializeComponent();
        BindingContext = new BasePageViewModel(navigationService);
    }
}