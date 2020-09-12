using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GraphicModelingDialogSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void LineButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EllipseButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RectangleButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PenButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AboutMe_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("My name is Milcho Arnaudov and I am a .NET Software Developer.");
        }
    }
}
