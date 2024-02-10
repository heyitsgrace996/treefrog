using Treefrog.Services;
using Treefrog.ViewModels;

namespace Treefrog.Views;

using Microsoft.Extensions.DependencyInjection;

public partial class BasePage : ContentPage
{
    public BasePage(INavigationService navigationService)
    {
        InitializeComponent();

        // Now, provide the navigation service to the BasePageViewModel
        BindingContext = new BasePageViewModel(navigationService);
    }

    public View ChildPageContent
    {
        set { ChildContent.Content = value; }
    }
}
