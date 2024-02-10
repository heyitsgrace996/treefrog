using Microsoft.Maui.Controls;
using Treefrog.Views;
using Treefrog.Services;
using Treefrog.ViewModels;

namespace Treefrog.Views
{
    public partial class HotDrinksPage : ContentPage
    {
        public HotDrinksPage(INavigationService navigationService, IMenuService menuService)
        {

            InitializeComponent();
            BindingContext = new HotDrinksViewModel(navigationService, menuService);


        }


    }
}
