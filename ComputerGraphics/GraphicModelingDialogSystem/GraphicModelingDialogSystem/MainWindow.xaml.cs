using GraphicModelingDialogSystem.FileOperations.Save;
using GraphicModelingDialogSystem.Utils;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Xml;

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
        private readonly IImageSaver imageSaver;
        private Point start;
        private Point end;

        public MainWindow()
        {
            InitializeComponent();

            this.currentShape = Enums.Shape.Line;
            this.shapeDrawer = new ShapeDrawer();
            this.solidColorBrushes = typeof(Brushes).GetProperties().Select((x) => (x.GetValue(null) as SolidColorBrush));
            this.imageSaver = new SaveImageToFile();
            this.AddColorsToMenus();
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
            this.currentShape = Enums.Shape.Pen;
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
            if (currentShape != Enums.Shape.Pen)
            {
                this.DrawShape();
            }
        }

        private void Sheet_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                end = e.GetPosition(this);

                if (currentShape == Enums.Shape.Pen)
                {
                    this.DrawShape();
                    this.start = e.GetPosition(this);
                }
            }
        }

        private void DrawShape()
        {
            Shape shape;

            switch (this.currentShape)
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
                case Enums.Shape.Pen:
                    shape = this.shapeDrawer.Pen(start, end);
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

            SolidColorBrush selectedColor = (SolidColorBrush)(new BrushConverter().ConvertFrom(ChooseColor.SelectedItem));

            this.shapeDrawer.Color = selectedColor;

            if (this.shapeDrawer.FillColor != Brushes.Transparent)
            {
                this.shapeDrawer.FillColor = selectedColor;
            }
        }

        private void SaveImage_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("The image will be saved in the /bin folder in a PNG format. Are you sure you want to proceed?", "Save Image?", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                this.imageSaver.SaveToPng(this.Sheet);
                MessageBox.Show("Image Saved Successfully!", "Saved!");
            }
        }

        private void SaveImageAs_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PNG Image (*.png)|*.png|JPEG Image (*.jpeg)|*.jpeg"
            };


            if (saveFileDialog.ShowDialog() == true)
            {
                this.imageSaver.FileName = saveFileDialog.FileName;

                if (saveFileDialog.FileName.Contains(".png"))
                {
                    this.imageSaver.SaveToPng(this.Sheet);
                    MessageBox.Show("Image Saved Successfully!", "Saved!");
                }
                else if (saveFileDialog.FileName.Contains(".jpeg"))
                {
                    this.Sheet.Background = Brushes.White;
                    this.imageSaver.SaveToJpeg(this.Sheet);
                    MessageBox.Show("Image Saved Successfully!", "Saved!");
                    this.Sheet.Background = Brushes.Transparent;
                }
            }
        }

        private void SaveModel_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("The image model will be saved in the /bin folder. Are you sure you want to proceed?", "Save Model?", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                this.imageSaver.SaveModel(this.Sheet);
                MessageBox.Show("Model Saved Successfully!", "Saved!");
            }
        }

        private void OpenModel_Click(object sender, RoutedEventArgs e)
        {

            string modelAsString = String.Empty;
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true)
            {
                modelAsString = File.ReadAllText(openFileDialog.FileName);
            }

            StringReader stringReader = new StringReader(modelAsString);
            XmlReader xmlReader = XmlReader.Create(stringReader);
            Canvas model = (Canvas)XamlReader.Load(xmlReader);
            List<FrameworkElement> childrenList = model.Children.Cast<FrameworkElement>().ToList();
            Sheet.Children.Clear();

            foreach (var child in childrenList)
            {
                model.Children.Remove(child);
                Sheet.Children.Add(child);
            }
        }
    }
}
