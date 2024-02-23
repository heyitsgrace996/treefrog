using Treefrog.ViewModels;
using Treefrog.Services;

namespace Treefrog.Views;

public partial class ProfilePage : ContentPage
{
    public ProfilePage(INavigationService navigationService)
    {

        InitializeComponent();
        BindingContext = new ProfileViewModel(navigationService);
    }


    private void OnSaveButtonClicked(object sender, System.EventArgs e)
    {
        var viewModel = (ProfileViewModel)BindingContext;
        viewModel.SaveUserData();

        DisplayAlert("Success", "Profile saved successfully", "OK");
    }
}