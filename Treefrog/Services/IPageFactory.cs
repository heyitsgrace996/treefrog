using System;
using System.Threading.Tasks; // Add this for Task
using Microsoft.Maui.Controls; // Add this for Page
using Microsoft.Extensions.DependencyInjection; // Add this for GetRequiredService

namespace Treefrog.Services
{
    public interface IPageFactory
    {
        Task NavigateToAsync(string route);
    }




    public class PageFactory : IPageFactory
    {
        public async Task NavigateToAsync(string route)
        {
            await Shell.Current.GoToAsync(route);
        }
    }
}

