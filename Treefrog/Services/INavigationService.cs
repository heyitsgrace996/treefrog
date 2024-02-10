using System;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace Treefrog.Services
{
    public interface INavigationService
    {
        Task NavigateToAsync(string route);
    }

    public class NavigationService : INavigationService
    {
        public NavigationService()
        {
        }

        public Task NavigateToAsync(string route)
        {
            // Use Shell.Current.GoToAsync to navigate based on route name
            return Shell.Current.GoToAsync(route);
        }
    }
}
