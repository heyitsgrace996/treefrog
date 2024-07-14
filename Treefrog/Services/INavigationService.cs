//Handles navigation between pages
//See AppShell.xaml for routing names

using Treefrog.ViewModels;
using Treefrog.Views;

namespace Treefrog.Services
{

    public interface INavigationService
    {
        Task NavigateToAsync(string route);
    }

    public class NavigationService : INavigationService
    {
        private readonly IServiceProvider _serviceProvider;

        public NavigationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task NavigateToAsync(string route)
        {
            if (route == "///checkout")
            {
                var viewModel = _serviceProvider.GetRequiredService<CheckoutViewModel>();
                var checkoutPage = new CheckoutPage(viewModel);
                return Shell.Current.Navigation.PushAsync(checkoutPage);
            }

            
            // Use Shell.Current.GoToAsync to navigate based on route name
            return Shell.Current.GoToAsync(route);
        }

    }
}