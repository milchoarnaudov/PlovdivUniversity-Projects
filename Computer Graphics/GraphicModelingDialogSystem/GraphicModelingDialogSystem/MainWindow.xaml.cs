using GraphicModelingDialogSystem.Utils;
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
        private ShapeDrawer shapeDrawer;
        private Enums.Shape currentShape;
        private Point start;
        private Point end;

        public MainWindow()
        {
            InitializeComponent();

            this.currentShape = Enums.Shape.Line;
            shapeDrawer = new ShapeDrawer();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void LineButton_Click(object sender, RoutedEventArgs e)
        {
            this.currentShape = Enums.Shape.Line;
        }

        private void EllipseButton_Click(object sender, RoutedEventArgs e)
        {
            this.currentShape = Enums.Shape.Ellipse;
        }

        private void RectangleButton_Click(object sender, RoutedEventArgs e)
        {
            this.currentShape = Enums.Shape.Rectangle;
        }

        private void PenButton_Click(object sender, RoutedEventArgs e)
        {
            // TODO
        }

        private void AboutMe_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("My name is Milcho Arnaudov and I am a .NET Software Developer.");
        }

        private void Sheet_MouseDown(object sender, MouseButtonEventArgs e)
        {
            start = e.GetPosition(this);
        }

        private void Sheet_MouseUp(object sender, MouseButtonEventArgs e)
        {
            DrawShape(currentShape);
        }

        private void Sheet_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                end = e.GetPosition(this);
            }
        }

        private void DrawShape(Enums.Shape currentShape)
        {
            Shape shape;

            switch (currentShape)
            {
                case Enums.Shape.Line:
                    shape = shapeDrawer.DrawLine(start, end);
                    break;
                case Enums.Shape.Ellipse:
                    shape = shapeDrawer.DrawEllipse(start, end);
                    break;
                case Enums.Shape.Rectangle:
                    shape = shapeDrawer.DrawRectangle(start, end);
                    break;
                default: throw new Exception("Shape is not selected");
            }

            Sheet.Children.Add(shape);
        }
    }
}
