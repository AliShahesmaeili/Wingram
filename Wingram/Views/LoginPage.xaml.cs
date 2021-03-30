using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Wingram.Classes.ViewModels;
using Wingram.Views.Controls;
using Wingram.Views.Pages;

namespace Wingram.Views
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : InstaPage
    {
        LoginViewModel LoginViewModel => DataContext as LoginViewModel;
        public LoginPage()
        {
            InitializeComponent();
        }
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            LoginViewModel.Password = ((PasswordBox)sender).Password;
        }
        private void TextBlockLoginHelp_MouseUp(object sender, MouseButtonEventArgs e)
        {
            LoginViewModel.ApplicationViewModel.Navigate(typeof(LoginHelpPage), false);
        }
    }
}
