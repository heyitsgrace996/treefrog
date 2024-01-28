using System;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using Treefrog.Views;
using Treefrog.Views.Menus;

namespace Treefrog.ViewModels
{
    public class MainPageViewModel
    {
        public ICommand NavigateToHotDrinksCommand { get; }
        public ICommand NavigateToColdDrinksCommand { get; }
        public ICommand NavigateToHotFoodCommand { get; }
        public ICommand NavigateToBakeryCommand { get; }

        public MainPageViewModel()
        {
            NavigateToHotDrinksCommand = new Command(NavigateToHotDrinks);
            NavigateToColdDrinksCommand = new Command(NavigateToColdDrinks);
            NavigateToHotFoodCommand = new Command(NavigateToHotFood);
            NavigateToBakeryCommand = new Command(NavigateToBakery);
        }

        private async void NavigateToHotDrinks()
        {
            // Navigate to HotDrinksPage
            // You can use App.Current.MainPage.Navigation for navigation in .NET MAUI
            await App.Current.MainPage.Navigation.PushAsync(new HotDrinksPage());
        }

        private async void NavigateToColdDrinks()
        {
            // Navigate to ColdDrinksPage
            await App.Current.MainPage.Navigation.PushAsync(new ColdDrinksPage());
        }

        private async void NavigateToHotFood()
        {
            // Navigate to HotFoodPage
            await App.Current.MainPage.Navigation.PushAsync(new HotFoodPage());
        }

        private async void NavigateToBakery()
        {
            // Navigate to BakeryPage
            await App.Current.MainPage.Navigation.PushAsync(new BakeryPage());
        }
    }
}
