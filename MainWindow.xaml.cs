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
            var buttons = new FrameworkElement[] { this.button1, this.button2, this.button3, this.button4 };
            var origin = this.grid.PointToScreen(new Point(0.0d, 0.0d));

            foreach (var component in buttons)
            {
                var border = new Border();
                var pt = component.PointToScreen(new Point(0.0d, 0.0d));
                var margin = 10;

                border.Width = component.Width + (margin * 2);
                border.Height = component.Height + (margin * 2);
                border.BorderBrush = new SolidColorBrush(Colors.Red);
                border.BorderThickness = new Thickness(3);
                border.CornerRadius = new CornerRadius(10);

                Canvas.SetLeft(border, pt.X - origin.X - margin);
                Canvas.SetTop(border, pt.Y - origin.Y - margin);

                this.canvas.Children.Add(border);
            }
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
