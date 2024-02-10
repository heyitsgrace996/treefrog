using System.Collections.ObjectModel;
using Treefrog.Services;
using Treefrog.Models;

namespace Treefrog.ViewModels
{
    public class TestViewModel : BasePageViewModel
    {
       
        private readonly INavigationService _navigationService;

        public TestViewModel(INavigationService navigationService) : base(navigationService)
        {
           
            _navigationService = navigationService;
        }
    }
}