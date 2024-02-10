using Treefrog.ViewModels;
using Treefrog.Services;

namespace Treefrog.Views;

public partial class RewardsPage : ContentPage
{
    public RewardsPage(INavigationService navigationService)
    {

        InitializeComponent();
        BindingContext = new RewardsViewModel(navigationService);
    }
}
