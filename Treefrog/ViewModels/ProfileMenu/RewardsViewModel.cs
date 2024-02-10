using System;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Treefrog.Services;
using Treefrog.Models; // Make sure to include this if MenuItem is within this namespace

namespace Treefrog.ViewModels
{
    public class RewardsViewModel : BasePageViewModel
    {
        private INavigationService _navigationService;

        public RewardsViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
        }

    }
}


