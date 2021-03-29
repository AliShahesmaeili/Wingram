using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wingram.Classes.ViewModels;
using Wingram.Enums;
using Wingram.Views.Controls;

namespace Wingram.Views
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : InstaPage
    {
        LoginViewModel loginViewModel => DataContext as LoginViewModel;
        public LoginPage()
        {
            InitializeComponent();
        }
        public override void PageLoad(PageLoadEnum pageLoadEnum, Dictionary<string, object> parameters)
        {

        }
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            loginViewModel.Password = ((PasswordBox)sender).Password;
        }

        private void TextBlockLoginHelp_MouseUp(object sender, MouseButtonEventArgs e)
        {
            loginViewModel.ApplicationViewModel.Navigate(typeof(LoginPage), false, new Dictionary<string, object>() { { "asdad", 1 } });
            // NavigationService.Navigate(new LoginPage());
        }
    }
}
