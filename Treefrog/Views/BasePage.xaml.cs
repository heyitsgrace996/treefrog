namespace Treefrog.Views;

public partial class BasePage : ContentPage
{
    public BasePage()
    {
        InitializeComponent();
        BindingContext = new ViewModels.BasePageViewModel();
    }

}