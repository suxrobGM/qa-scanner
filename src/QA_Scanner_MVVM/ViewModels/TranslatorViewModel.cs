using Awesomium.Windows.Controls;
using Prism.Commands;
using Prism.Mvvm;
using QA_Scanner.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA_Scanner_MVVM.ViewModels
{
    public class TranslatorViewModel : BindableBase
    {
        private string _inputText;

        public string NavigationSource { get => _inputText; set { SetProperty(ref _inputText, value); } }
        public DelegateCommand<WebControl> BackNavigateCommand { get; }
        public DelegateCommand<WebControl> ForwardNavigateCommand { get; }
        public DelegateCommand<WebControl> UpdatePageCommand { get; }
        public DelegateCommand PageLoadedCommand { get; }

        public TranslatorViewModel( )
        {
            NavigationSource = "https://translate.google.com";

            PageLoadedCommand = new DelegateCommand(() =>
            {
                BackNavigateCommand.RaiseCanExecuteChanged();
                ForwardNavigateCommand.RaiseCanExecuteChanged();
            });

            BackNavigateCommand = new DelegateCommand<WebControl>(browser =>
            {
                browser.GoBack();
            }, b => b !=null && b.CanGoBack());

            ForwardNavigateCommand = new DelegateCommand<WebControl>(browser =>
            {
                browser.GoForward();                
            }, b => b != null && b.CanGoForward());

            UpdatePageCommand = new DelegateCommand<WebControl>(browser =>
            {
                browser.Reload(false);
            });
        }
    }
}
