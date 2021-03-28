using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Wingram.Classes.Commons;
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
            Locator.LoadSessions();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var paletteHelper = new PaletteHelper();
            var theme = paletteHelper.GetTheme();
            theme.SetPrimaryColor(Color.FromRgb(101, 162, 248));
            theme.SetSecondaryColor(Color.FromRgb(126, 217, 61));
            paletteHelper.SetTheme(theme);
            LoadLanguages();
            new MainWindow().Show();
        }

        private void LoadLanguages()
        {
            var languageFolders = Directory.GetDirectories(Path.Combine(Classes.Constants.ApplicationDirectory, "Assets", "Languages"));

            foreach (var path in languageFolders)
            {
                var directoryInfo = new DirectoryInfo(path);
                string filename = Path.Combine(directoryInfo.FullName, "strings.xml");
                if (File.Exists(filename))
                {
                    LocalizationManager.Instance.AddCulture(
                        CultureInfo.GetCultureInfo(directoryInfo.Name.Replace("values-","")),
                        LocalizationXmlFileReader.GetEntries(filename));
                }
            }

            LocalizationManager.Instance.CurrentCulture = CultureInfo.GetCultureInfo("fa");

        }
    }
}
