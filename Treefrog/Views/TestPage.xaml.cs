using Treefrog.Services;
using Treefrog.ViewModels;
namespace Treefrog.Views;

public partial class TestPage : ContentPage
{
	public TestPage(INavigationService navigationService)
	{
		InitializeComponent();
        BindingContext = new TestViewModel(navigationService);
    }
}
