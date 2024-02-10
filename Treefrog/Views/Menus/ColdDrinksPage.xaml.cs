using Microsoft.Maui.Controls;
using Treefrog.Views;
using Treefrog.Services;
using Treefrog.ViewModels;

namespace Treefrog.Views
{
    public partial class ColdDrinksPage : ContentPage
    {
        public ColdDrinksPage(INavigationService navigationService, IMenuService menuService)
        { 

            InitializeComponent();
            BindingContext = new BakeryViewModel(navigationService, menuService);


        }


    }
}
