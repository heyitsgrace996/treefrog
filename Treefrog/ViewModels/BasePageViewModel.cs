using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using Treefrog.Services;
using Treefrog.Views;

namespace Treefrog.ViewModels
{
    public class BasePageViewModel : INotifyPropertyChanged
    {
        protected readonly INavigationService navigationService;

        //Controls the POPUP Menu
        private bool _isPopupMenuVisible;
        public bool IsPopupMenuVisible
        {
            get => _isPopupMenuVisible;
            set
            {
                _isPopupMenuVisible = value;
                OnPropertyChanged(nameof(IsPopupMenuVisible));
            }
        }

        //Control the Bottom Buttons (only needed for Main Page)
        private bool _showBottomButtons = true; // Default to true
        public bool ShowBottomButtons
        {
            get => _showBottomButtons;
            set
            {
                _showBottomButtons = value;
                OnPropertyChanged(nameof(ShowBottomButtons));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        //commands for bottom + top buttons
        public ICommand NavigateToHotDrinksCommand { get; private set; }
        public ICommand NavigateToColdDrinksCommand { get; private set; }
        public ICommand NavigateToHotFoodCommand { get; private set; }
        public ICommand NavigateToBakeryCommand { get; private set; }
        public ICommand NavigateToMainPageCommand { get; private set; }
        public ICommand NavigateToTestCommand { get; private set; }

        // Commands for pop-up menu items
        public ICommand NavigateToProfileCommand { get; private set; }
        public ICommand NavigateToOrderHistoryCommand { get; private set; }
        public ICommand NavigateToAboutCommand { get; private set; }
        public ICommand NavigateToContactUsCommand { get; private set; }
        public ICommand NavigateToBasketCommand { get; private set; }
        public ICommand NavigateToCheckoutCommand { get; private set; }
        public ICommand NavigateToOrderConfCommand { get; set; }



        // Command to toggle the visibility of the pop-up menu
        public ICommand TogglePopupMenuVisibilityCommand { get; private set; }



        public BasePageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService), "NavigationService must be provided.");

            // Debugging: Check navigationService value
            Debug.WriteLine($"Navigation service is initialized: {navigationService != null}");

            InitializeCommands();


            TogglePopupMenuVisibilityCommand = new Command(() => IsPopupMenuVisible = !IsPopupMenuVisible);
            IsPopupMenuVisible = false;

        }

        protected ICommand CreateNavigationCommand(string route, string debugMessage)
        {
            return new Command(async () =>
            {
                Debug.WriteLine($"Attempting to navigate to {debugMessage}...");
                
                try
                {
                    await navigationService.NavigateToAsync($"///{route}");
                    Debug.WriteLine($"Successfully navigated to {debugMessage}.");
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Failed to navigate to {debugMessage}. Exception: {ex}");
                }
            });
        }

        private void InitializeCommands()
        {
            NavigateToHotDrinksCommand = CreateNavigationCommand("hotdrinks", "hot drinks");
            NavigateToColdDrinksCommand = CreateNavigationCommand("colddrinks", "cold drinks");
            NavigateToHotFoodCommand = CreateNavigationCommand("hotfood", "hot food");
            NavigateToBakeryCommand = CreateNavigationCommand("bakery", "bakery");
            NavigateToMainPageCommand = CreateNavigationCommand("mainpage", "mainpage");
            NavigateToTestCommand = CreateNavigationCommand("test", "test");

            NavigateToProfileCommand = CreateNavigationCommand("profile", "Profile");
            NavigateToOrderHistoryCommand = CreateNavigationCommand("orderhistory", "Order History");
            NavigateToAboutCommand = CreateNavigationCommand("about", "About");
            NavigateToContactUsCommand = CreateNavigationCommand("contactus", "Contact Us");
            NavigateToBasketCommand = CreateNavigationCommand("basket", "Basket");
            NavigateToCheckoutCommand = CreateNavigationCommand("checkout", "Checkout");
            NavigateToOrderConfCommand = CreateNavigationCommand("orderconf", "OrderConf");


        }


        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
