using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Wingram.Classes.Commons;
using Wingram.Interfaces;

namespace Wingram.Classes.ViewModels
{
    public class LoginViewModel : InstaBaseViewModel
    {
        #region Privates
        private string username, password;
        private bool isLoading;
        #endregion

        #region Publics
        public RelayCommand LoginCommand { get; }
        public string Username
        {
            get => username;
            set => Set(ref username, value);
        }
        public string Password
        {
            get => password;
            set => Set(ref password, value);
        }
        public bool IsLoading
        {
            get => isLoading;
            set => Set(ref isLoading, value);
        }
        #endregion

        #region Constractors
        public LoginViewModel(IInstagramService instagramService, ApplicationViewModel applicationViewModel) : base(instagramService, applicationViewModel)
        {
            LoginCommand = new RelayCommand(LoginAsync);
        }
        #endregion

        #region Functions
        public async void LoginAsync()
        {
            IsLoading= ApplicationViewModel.IsLoading = true;
            InstagramService.InstagramApi().SetUser(Username, Password);
            var result = await InstagramService.InstagramApi().LoginAsync();
            if (result.Succeeded)
            {
                // await PopupMessage.ShowAsync(result.OtherValue.Message, result.OtherValue.ErrorTitle);
            }
            else if (result.OtherValue != null)
            {
                var popupResult = await PopupMessage.ShowAsync(result.OtherValue.Message, result.OtherValue.ErrorTitle, result.OtherValue.Buttons);
                if (popupResult.Item2.Equals("login_with_facebook"))
                {

                }
                else if (popupResult.Item2.Equals("forgot_password_flow"))
                {

                }
                else if (popupResult.Item2.Equals("switch_to_signup_flow"))
                {

                }
                else if (popupResult.Item2.Equals("send_password_reset_email"))
                {

                }
                else if (popupResult.Item2.Equals("send_one_click_login_email"))
                {

                }
                else if (popupResult.Item2.Equals("go_to_helper_url"))
                {

                }
                else if (popupResult.Item2.Equals("dismiss"))
                {

                }
            }
            else
            {
                await PopupMessage.ShowAsync(result.Info.Message, "Error", "Ok");
            }
            IsLoading= ApplicationViewModel.IsLoading = false;
        }
        #endregion
    }
}
