using System.IO;
using System.Windows;
using Prism.Ioc;
using Prism.Unity;
using QA_Scanner_MVVM.Models;
using QA_Scanner_MVVM.Views;

namespace QA_Scanner_MVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        public static string SettingsFile = "settings.json";

        public App()
        {
            InitializeAppSettings();
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }

        private void InitializeAppSettings()
        {
            if (!File.Exists(SettingsFile) || string.IsNullOrWhiteSpace(File.ReadAllText(SettingsFile)))
            {
                File.Create(SettingsFile).Close();
                var settings = new AppSettings()
                {
                    IsAsynchronousFinding = false,
                    Opacity = 1.0
                };
            }           
        }
    }
}
