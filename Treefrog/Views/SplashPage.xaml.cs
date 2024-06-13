using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Treefrog.Views;

public partial class SplashPage : ContentPage
{
    public SplashPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await Task.Delay(100);

        // Start the animation when page appears
        treefrog_fly.IsAnimationPlaying = false;
        await Task.Delay(100);
        treefrog_fly.IsAnimationPlaying = true;

        // Simulate some initialization tasks
        await SimulateInitializationAsync();

        // After initialization tasks, navigate to the main page
        Application.Current.MainPage = new AppShell();
    }

    private async Task SimulateInitializationAsync()
    {
        // Simulate initialization progress
        for (int i = 0; i <= 100; i += 10)
        {
            // Update progress bar
            progressBar.Progress = i / 100.0;

            // Simulate some processing time
            await Task.Delay(500);
        }
    }
}
