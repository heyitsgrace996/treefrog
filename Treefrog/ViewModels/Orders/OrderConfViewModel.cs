using Treefrog.Services;


namespace Treefrog.ViewModels
{
    public class OrderConfViewModel : BasePageViewModel
    {
        private INavigationService _navigationService;

        public OrderConfViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
        }

    }
}

