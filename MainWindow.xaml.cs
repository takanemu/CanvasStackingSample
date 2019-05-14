using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace CanvasStackingSample
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var index = 0;
            var component = new UIElement[] { this.help1, this.help2, this.help3, this.help4 };
            var dispatcherTimer = new DispatcherTimer(DispatcherPriority.Normal);
            var origin = this.grid.PointToScreen(new Point(0.0d, 0.0d));
            var pt = new Point[] {
                this.button1.PointToScreen(new Point(0.0d, 0.0d)),
                this.button2.PointToScreen(new Point(0.0d, 0.0d)),
                this.button3.PointToScreen(new Point(0.0d, 0.0d)),
                this.button4.PointToScreen(new Point(0.0d, 0.0d)),
            };
            for(var i = 0; i < component.Length; i++)
            {
                Canvas.SetLeft(component[i], pt[i].X - origin.X);
                Canvas.SetTop(component[i], pt[i].Y - origin.Y);
            }
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 1);
            dispatcherTimer.Tick += new EventHandler((s, ea) => {
                foreach(var element in component)
                {
                    element.Visibility = Visibility.Collapsed;
                }
                component[index++].Visibility = Visibility.Visible;
                index = index >= 4 ? 0 : index;
            });
            dispatcherTimer.Start();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            this.canvas.Background = null;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            this.canvas.Background = new SolidColorBrush(Colors.Transparent);
        }
    }
}
