using System;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Treefrog.Services;
using Treefrog.Models; // Make sure to include this if MenuItem is within this namespace

namespace Treefrog.ViewModels
{
    public class ProfileViewModel : BasePageViewModel
    {
        private INavigationService _navigationService;

        private string _userName;
        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }

        private string _userEmail;
        public string UserEmail
        {
            get => _userEmail;
            set
            {
                _userEmail = value;
                OnPropertyChanged(nameof(UserEmail));
            }
        }

        private string _userPhone;
        public string UserPhone
        {
            get => _userPhone;
            set
            {
                _userPhone = value;
                OnPropertyChanged(nameof(UserPhone));
            }
        }


        public ProfileViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
            LoadUserData();
        }

        private void LoadUserData()
        {
            UserName = Preferences.Get("UserName", string.Empty);
            UserEmail = Preferences.Get("UserEmail", string.Empty);
            UserPhone = Preferences.Get("UserPhone", string.Empty);
        }

        public void SaveUserData()
        {
            // Save user data to preferences
            Preferences.Set("UserName", UserName);
            Preferences.Set("UserEmail", UserEmail);
            Preferences.Set("UserPhone", UserPhone);
        }
    }

}

