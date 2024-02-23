using Treefrog.Services;
using Treefrog.ViewModels;

namespace Treefrog
{
    public partial class MainPage : ContentPage
    {
        public MainPage(INavigationService navigationService)
        {
            InitializeComponent();
            this.BindingContext = new MainPageViewModel(navigationService);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (BindingContext is MainPageViewModel viewModel)
            {
                viewModel.IsPopupMenuVisible = false;
            }
         
        }

    }
}
