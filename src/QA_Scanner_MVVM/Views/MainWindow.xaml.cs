using System.Windows;
using System.Windows.Input;
using QA_Scanner.PlatformSpecific;
using QA_Scanner_MVVM.Models;

namespace QA_Scanner_MVVM.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly HotKey _hKey;
        private readonly HotKey _sliderPlus;
        private readonly HotKey _sliderMinus;
        private readonly AppSettings _settings;

        public MainWindow()
        {
            _settings = AppSettings.FromJsonFile();
            InitializeComponent();           
            
            _hKey = new HotKey(Key.D, KeyModifier.Ctrl, SetVisible);
            _sliderPlus = new HotKey(Key.Multiply, KeyModifier.None, AddOpacity);
            _sliderMinus = new HotKey(Key.Subtract, KeyModifier.None, SubtractOpacity);
            opacitySlider.Value = _settings.Opacity * 100;
            Opacity = _settings.Opacity;
        }       

        private void SetVisible(HotKey hotKey)
        {
            if (Visibility == Visibility.Visible)
                Visibility = Visibility.Collapsed;
            else
                Visibility = Visibility.Visible;
        }

        private void AddOpacity(HotKey hotKey)
        {
            if (opacitySlider.Value < opacitySlider.Maximum)
            {
                opacitySlider.Value++;
                Opacity = opacitySlider.Value / 100.0;
                _settings.Opacity = Opacity;
            }
        }

        private void SubtractOpacity(HotKey hotKey)
        {
            if (opacitySlider.Value > opacitySlider.Minimum)
            {
                opacitySlider.Value--;
                Opacity = opacitySlider.Value / 100.0;
                _settings.Opacity = Opacity;
            }
        }

        private void OpacitySlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {          
            if (IsInitialized)
            {
                Opacity = opacitySlider.Value / 100.0;
                _settings.Opacity = Opacity;
            }
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }
    }
}
