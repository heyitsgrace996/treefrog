using Microsoft.Maui.Controls;
using Treefrog.Services;
using Treefrog.ViewModels;

namespace Treefrog.Views
{
    public partial class HotFoodPage : ContentPage
    {
        public HotFoodPage(INavigationService navigationService, IMenuService menuService)
        {
            InitializeComponent(); // Initialize the components from XAML

            // Set the BindingContext for the page
            BindingContext = new HotFoodViewModel(navigationService, menuService);
        }
    }
}
