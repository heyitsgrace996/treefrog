using Microsoft.Maui.Controls;
using Treefrog.Views;
using Treefrog.Services;
using Treefrog.ViewModels;

namespace Treefrog.Views
{
    public partial class BakeryPage: ContentPage
    {
        public BakeryPage(INavigationService navigationService, IMenuService menuService)
        {

            InitializeComponent();
            BindingContext = new BakeryViewModel(navigationService, menuService);


        }


    }
}
