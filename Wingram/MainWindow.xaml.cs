using Microsoft.EntityFrameworkCore;
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
using Wingram.Classes;
using Wingram.Views;
using Wingram.Views.Controls;

namespace Wingram
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : InstaWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FrameMain.Navigate(new LoginPage());

            //using var context = new WingramContext();
            //await context.Account.AddAsync(new Instagram.Classes.Account() { Username = "asd", InstagramId = 5432 });
            //await context.SaveChangesAsync();

         //   var asdasd =await context.Account.ToListAsync();
        }

        private void FrameMain_Navigated(object sender, NavigationEventArgs e)
        {
            FrameMain.NavigationService.RemoveBackEntry();
        }
    }
}
