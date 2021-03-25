using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
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

        protected async override void OnStartup(StartupEventArgs e)
        {
           // await Locator.LoadSessionsAsync();
        }
    }
}
