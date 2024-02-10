using Treefrog.Services;
using Treefrog.ViewModels;

namespace Treefrog;

public partial class App : Application
{

    public App()
    {
        InitializeComponent();

        // Set the Shell defined in your AppShell.xaml as the main page
        MainPage = new AppShell();

    }
}