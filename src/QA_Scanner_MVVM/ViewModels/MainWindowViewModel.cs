using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
