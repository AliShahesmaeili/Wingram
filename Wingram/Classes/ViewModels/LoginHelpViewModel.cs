using Wingram.Classes.Commons;
using Wingram.Interfaces;
using Wingram.Views.Pages;

namespace Wingram.Classes.ViewModels
{
    public class LoginHelpViewModel : InstaBaseViewModel
    {
        #region Privates
        private string usernameEmailPhone;
        private bool isLoading, activeNextButton;
        #endregion

        #region Publics
        public RelayCommand LoginCommand { get; }
        public RelayCommand NextCommand { get; }
        public string UsernameEmailPhone
        {
            get => usernameEmailPhone;
            set
            {
                Set(ref usernameEmailPhone, value);
                ActiveNextButton = !string.IsNullOrWhiteSpace(usernameEmailPhone);
            }
        }
        public bool IsLoading
        {
            get => isLoading;
            set => Set(ref isLoading, value);
        }
        public bool ActiveNextButton
        {
            get => activeNextButton;
            set => Set(ref activeNextButton, value);
        }
        #endregion

        #region Constractors
        public LoginHelpViewModel(IInstagramService instagramService, ApplicationViewModel applicationViewModel) : base(instagramService, applicationViewModel)
        {
            LoginCommand = new RelayCommand(Login);
            NextCommand = new RelayCommand(Next);
        }
        #endregion

        #region Functions
        public void Login()
        {
            ApplicationViewModel.Navigate(typeof(LoginPage), false);
        }

        public void Next()
        {
            
        }
        #endregion
    }
}
