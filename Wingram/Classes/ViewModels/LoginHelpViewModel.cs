using Wingram.Classes.Commons;
using Wingram.Interfaces;
using Wingram.Views.Pages;

namespace Wingram.Classes.ViewModels
{
    public class LoginHelpViewModel : InstaBaseViewModel
    {
        #region Privates
        private string usernameEmailPhone;
        private bool isLoading, activeLoginButton;
        #endregion

        #region Publics
        public RelayCommand LoginCommand { get; }
        public RelayCommand D { get; }
        public string UsernameEmailPhone
        {
            get => usernameEmailPhone;
            set
            {
                Set(ref usernameEmailPhone, value);
                ActiveLoginButton = !string.IsNullOrWhiteSpace(usernameEmailPhone);
            }
        }

        public bool IsLoading
        {
            get => isLoading;
            set => Set(ref isLoading, value);
        }
        public bool ActiveLoginButton
        {
            get => activeLoginButton;
            set => Set(ref activeLoginButton, value);
        }
        #endregion

        #region Constractors
        public LoginHelpViewModel(IInstagramService instagramService, ApplicationViewModel applicationViewModel) : base(instagramService, applicationViewModel)
        {
            LoginCommand = new RelayCommand(Login);
        }
        #endregion

        #region Functions
        public void Login()
        {
            ApplicationViewModel.Navigate(typeof(LoginPage), false);
        }
        #endregion
    }
}
