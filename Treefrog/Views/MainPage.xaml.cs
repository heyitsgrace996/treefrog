using Treefrog.Services;
using Treefrog.ViewModels;
using Microsoft.Maui.Controls;

namespace Treefrog
{
    public partial class MainPage : ContentPage
    {
        public MainPage(INavigationService navigationService) // Change parameter type to INavigationService
        {
            InitializeComponent();
            this.BindingContext = new MainPageViewModel(navigationService);
        }
    }
}
