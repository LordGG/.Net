using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using LuxDimmer.Properties;
using LuxDimmer.Utils;

namespace LuxDimmer
{
    public class MonitoredScreen : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region Commands
        private ICommand _toggleVisibilityCommand;

        public ICommand ToggleVisibilityCommand
        {
            get
            {
                if (_toggleVisibilityCommand == null)
                {
                    _toggleVisibilityCommand = new RelayCommand(param => this.ToggleVisibility());
                }
                return _toggleVisibilityCommand;
            }
        }

        private ICommand _resetVisibilityCommand;

        public ICommand ResetVisibilityCommand
        {
            get
            {
                if (_resetVisibilityCommand == null)
                {
                    _resetVisibilityCommand = new RelayCommand(param => this.ResetVisibility());
                }
                return _resetVisibilityCommand;
            }
        }
        #endregion

        #region Attributes and properties
        private int Id { get; set; }
        private Screen CurrentScreen { get; set; }
        private Overlay OverlayWindow { get; set; }

        private string _powerButtonImageSource;
        public string PowerButtonImageSource
        {
            get { return _powerButtonImageSource; }
            set
            {
                _powerButtonImageSource = value;
                RaisePropertyChanged("PowerButtonImageSource");
            }
        }
        public string MonitorLabel => string.Format("Screen {0}", Id);

        private int _brightness;
        public int Brightness
        {
            get { return _brightness; }

            set
            {
                _brightness = value;
                SetBrightness(_brightness);
                RaisePropertyChanged("Brightness");
            }
        }
        #endregion

        public MonitoredScreen(int id, Screen screen)
        {
            Id = id;
            CurrentScreen = screen;
            OverlayWindow = new Overlay();
            Brightness = 0;
            PowerButtonImageSource = "Content/on.png";
        }

        private void ToggleVisibility()
        {
            if (OverlayWindow.IsVisible)
            {
                OverlayWindow.Visibility = Visibility.Hidden;
                PowerButtonImageSource = "Content/off.png";
            }
            else
            {
                OverlayWindow.Visibility = Visibility.Visible;
                PowerButtonImageSource = "Content/on.png";
            }
        }

        private void ResetVisibility()
        {
            Brightness = 0;
        }

        public void Show()
        {
            OverlayWindow.WindowStartupLocation = WindowStartupLocation.Manual;

            OverlayWindow.Left = CurrentScreen.Bounds.Left;
            OverlayWindow.Top = CurrentScreen.Bounds.Top;
            OverlayWindow.Width = CurrentScreen.Bounds.Width;
            OverlayWindow.Height = CurrentScreen.Bounds.Height;

            //OverlayWindow.SourceInitialized += (snd, arg) =>
            //    OverlayWindow.WindowState = WindowState.Maximized;
            OverlayWindow.Show();
            PowerButtonImageSource = "Content/on.png";
        }

        /// <summary>
        /// -100 < brightness < 100
        /// </summary>
        /// <param name="brightness"></param>
        private void SetBrightness(int brightness)
        {
            if (brightness > 0)
            {
                OverlayWindow.Background = new SolidColorBrush(Colors.White) {Opacity = (double) brightness/100};
            }
            else if (brightness < 0)
            {
                OverlayWindow.Background = new SolidColorBrush(Colors.Black) {Opacity = (double) -brightness/100};
            }
            else
            {
                OverlayWindow.Background = new SolidColorBrush(Colors.Transparent);
            }
        }

        private void RaisePropertyChanged(String property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}
