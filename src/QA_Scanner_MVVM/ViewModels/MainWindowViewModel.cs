using System;
using System.Diagnostics;
using Prism.Commands;

namespace QA_Scanner_MVVM.ViewModels
{
    public class MainWindowViewModel
    {
        public DelegateCommand<string> GoToWebSiteCommand { get; }
        public DelegateCommand CloseAppCommand { get; }

        public MainWindowViewModel()
        {
            GoToWebSiteCommand = new DelegateCommand<string>(url =>
            {
                Process.Start(url);
            });

            CloseAppCommand = new DelegateCommand(() =>
            {
                Environment.Exit(0);
            });
        }
    }
}
