using Treefrog.ViewModels;
using Treefrog.Services;
namespace Treefrog.Views
{
    public partial class CheckoutPage : ContentPage
    {
        
        private readonly ProfileViewModel _profileViewModel;
        private readonly INavigationService _navigationService;
        private readonly IBasketService _basketService;
        private readonly IOrderService _orderService;
        

        public CheckoutPage(ProfileViewModel profileViewModel, INavigationService navigationService, IBasketService basketService, IOrderService orderService)
        {

            _profileViewModel = profileViewModel;
            _navigationService = navigationService;
            _basketService = basketService;
            _orderService = orderService;

            InitializeComponent();
            
            BindingContext = new CheckoutViewModel(_profileViewModel, _navigationService, _basketService, _orderService);

        
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            if (BindingContext is CheckoutViewModel viewModel)
            {
                viewModel.ResetViewModel(); 
            }
        }
    }
}
