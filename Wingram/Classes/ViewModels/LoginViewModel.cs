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
        private ICommand loginCommand;
        private string username, password;
        public LoginViewModel(IInstagramService instagramService) : base(instagramService)
        {
            LoginCommand = new RelayCommand(LoginAsync);
        }

        
        public ICommand LoginCommand
        {
            get => loginCommand;
            set => Set(ref loginCommand, value);
        }
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
        public async void LoginAsync()
        {
            InstagramService.InstagramApi().SetUser(Username, Password);
            var result = await InstagramService.InstagramApi().LoginAsync();
        }
    }
}
