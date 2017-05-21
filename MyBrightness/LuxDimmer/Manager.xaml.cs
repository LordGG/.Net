using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ContextMenu = System.Windows.Forms.ContextMenu;
using MenuItem = System.Windows.Forms.MenuItem;

namespace LuxDimmer
{
    /// <summary>
    /// Logique d'interaction pour Manager.xaml
    /// </summary>
    public partial class Manager : Window
    {
        private NotifyIcon _notifyIcon = new NotifyIcon();
        private List<MonitoredScreen> _screens = new List<MonitoredScreen>();

        public Manager()
        {
            InitializeComponent();
            DataContext = this;

            for (int i = 1; i <= Screen.AllScreens.Length; i++)
            {
                _screens.Add(new MonitoredScreen(i, Screen.AllScreens[i-1]));
                _screens[i-1].Show();
            }

            lstMonitorManagers.ItemsSource = _screens;

            this.ShowInTaskbar = false;
            this._notifyIcon.Icon = LuxDimmer.Properties.Resources.brightnesslight48;
            this._notifyIcon.Visible = true;

            MenuItem exitMenuItem = new MenuItem("Exit", new EventHandler(Exit));
            _notifyIcon.Click += new EventHandler(ShowManager);
            _notifyIcon.ContextMenu = new ContextMenu(new MenuItem[] { exitMenuItem });
        }

        void ShowManager(object sender, EventArgs e)
        {
            if (this.IsVisible)
            {
                this.Visibility = Visibility.Hidden;
            }
            else
            {
                this.Visibility = Visibility.Visible;
                this.WindowState = System.Windows.WindowState.Normal;
            }
        }

        void Exit(object sender, EventArgs e)
        {
            _notifyIcon.Visible = false;
            Environment.Exit(0);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;
        }

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);
            MoveBottomRightEdgeOfWindowToMousePosition();
        }

        private void MoveBottomRightEdgeOfWindowToMousePosition()
        {
            var transform = PresentationSource.FromVisual(this).CompositionTarget.TransformFromDevice;
            var mouse = transform.Transform(GetMousePosition());
            Left = mouse.X - ActualWidth;
            Top = mouse.Y - ActualHeight;
        }

        public System.Windows.Point GetMousePosition()
        {
            System.Drawing.Point point = System.Windows.Forms.Control.MousePosition;
            return new System.Windows.Point(point.X, point.Y);
        }

        private void Window_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }
    }
}
