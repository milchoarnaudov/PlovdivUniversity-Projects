using GraphicModelingDialogSystem.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        private readonly ShapeDrawer shapeDrawer;
        private readonly IEnumerable<SolidColorBrush> solidColorBrushes;
        private Enums.Shape currentShape;
        private Point start;
        private Point end;

        public MainWindow()
        {
            InitializeComponent();

            this.currentShape = Enums.Shape.Line;
            shapeDrawer = new ShapeDrawer();

            this.solidColorBrushes = typeof(Brushes).GetProperties().Select((x) =>
            {
                return (x.GetValue(null) as SolidColorBrush);
            });

            AddColorsToMenus();
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
                    shape = this.shapeDrawer.DrawLine(start, end);
                    break;
                case Enums.Shape.Ellipse:
                    shape = this.shapeDrawer.DrawEllipse(start, end);
                    break;
                case Enums.Shape.Rectangle:
                    shape = this.shapeDrawer.DrawRectangle(start, end);
                    break;
                default: throw new Exception("Shape is not selected");
            }

            this.Sheet.Children.Add(shape);
        }

        private void ClearSheet_Click(object sender, RoutedEventArgs e)
        {
            this.Sheet.Children.Clear();
            MessageBox.Show("The sheet is cleared.");
        }

        private void Opacity_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!this.IsLoaded) return;

            this.shapeDrawer.Opacity = this.OpacitySlider.Value;
        }

        private void AddColorsToMenus()
        {
            this.ChooseColor.ItemsSource = this.solidColorBrushes.Select(x => x.Color.ToString());
        }

        private void FillShape_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!this.IsLoaded) return;

            switch (this.FillShape.SelectedIndex)
            {
                case 0:
                    this.shapeDrawer.FillColor = Brushes.Transparent;
                    break;
                case 1:
                    this.shapeDrawer.FillColor = shapeDrawer.Color;
                    break;
            }
        }

        private void ChooseColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!this.IsLoaded) return;

            this.shapeDrawer.Color = (SolidColorBrush)(new BrushConverter().ConvertFrom(ChooseColor.SelectedItem));
        }
    }
}
