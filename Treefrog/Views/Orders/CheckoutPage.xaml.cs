using Treefrog.ViewModels;
using Treefrog.Services;

namespace Treefrog.Views
{
    public partial class CheckoutPage : ContentPage
    {
        public CheckoutPage(CheckoutViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

           
        }
    }
}