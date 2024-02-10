using System;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using Treefrog.Services;
using System.ComponentModel;
using System.Diagnostics; // Add this for debugging
using System.Threading.Tasks; // Add this for Task
using Treefrog.Views;

namespace Treefrog.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private readonly INavigationService navigationService; // Add this field

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand NavigateToHotDrinksCommand { get; private set; }
        public ICommand NavigateToColdDrinksCommand { get; private set; }
        public ICommand NavigateToHotFoodCommand { get; private set; }
        public ICommand NavigateToBakeryCommand { get; private set; }
        public ICommand NavigateToTestCommand { get; private set; }

        public MainPageViewModel(INavigationService navigationService) // Correct parameter type
        {
            this.navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService), "NavigationService must be provided.");

            // Debugging: Check navigationService value
            Debug.WriteLine($"Navigation service is initialized: {navigationService != null}");

            InitializeCommands();
        }

        private ICommand CreateNavigationCommand(string route, string debugMessage)
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
            NavigateToTestCommand = CreateNavigationCommand("test", "test");
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

