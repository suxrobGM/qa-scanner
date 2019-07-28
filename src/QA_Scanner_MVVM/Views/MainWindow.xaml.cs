using System.Windows;
using System.Windows.Input;
using QA_Scanner.PlatformSpecific;

namespace QA_Scanner_MVVM.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private HotKey _hKey;
        private HotKey _sliderPlus;
        private HotKey _sliderMinus;

        public MainWindow()
        {
            InitializeComponent();
            _hKey = new HotKey(Key.D, KeyModifier.Ctrl, SetVisible);
            _sliderPlus = new HotKey(Key.Multiply, KeyModifier.None, AddOpacity);
            _sliderMinus = new HotKey(Key.Subtract, KeyModifier.None, SubtractOpacity);
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
                //_settings.Opacity = Opacity;
            }
        }

        private void SubtractOpacity(HotKey hotKey)
        {
            if (opacitySlider.Value > opacitySlider.Minimum)
            {
                opacitySlider.Value--;
                Opacity = opacitySlider.Value / 100.0;
                //_settings.Opacity = Opacity;
            }
        }

        private void OpacitySlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Opacity = opacitySlider.Value / 100.0;
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }
    }
}
