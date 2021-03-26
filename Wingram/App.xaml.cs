using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Wingram.Classes.ViewModels;

namespace Wingram
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public ViewModelLocator Locator { get; } = new ViewModelLocator();

        public App()
        {
            Locator.LoadSessionsAsync();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var paletteHelper = new PaletteHelper();
            var theme = paletteHelper.GetTheme();
            theme.SetPrimaryColor(Color.FromRgb(101, 162, 248));
            paletteHelper.SetTheme(theme);

            new MainWindow().Show();
        }
    }
}
