using Treefrog.ViewModels;
using Treefrog.Services;

namespace Treefrog.Views;

public partial class ProfilePage : ContentPage
{
    public ProfilePage(INavigationService navigationService)
    {

        InitializeComponent();
        BindingContext = new ProfileViewModel(navigationService);
    }
}