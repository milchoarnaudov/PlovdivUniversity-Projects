using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GraphicModelingDialogSystem
{
    class ShapeDrawer
    {
        public Rectangle DrawRectangle(Point start, Point end)
        {
            Rectangle rectangle = new Rectangle()
            {
                Stroke = Brushes.Blue,
                StrokeThickness = 4,
            };

            if (end.X >= start.X)
            {
                rectangle.SetValue(Canvas.LeftProperty, start.X);
                rectangle.Width = end.X - start.X;
            }
            else
            {
                rectangle.SetValue(Canvas.LeftProperty, end.X);
                rectangle.Width = start.X - end.X;
            }

            if (end.Y >= start.Y)
            {
                rectangle.SetValue(Canvas.TopProperty, start.Y - 50);
                rectangle.Height = end.Y - start.Y;
            }
            else
            {
                rectangle.SetValue(Canvas.TopProperty, end.Y - 50);
                rectangle.Height = start.Y - end.Y;
            }

            return rectangle;
        }

        public Ellipse DrawEllipse(Point start, Point end)
        {
            Ellipse ellipse = new Ellipse()
            {
                Stroke = Brushes.Blue,
                StrokeThickness = 4,
                Height = 10,
                Width = 10
            };

            if (end.X >= start.X)
            {
                ellipse.SetValue(Canvas.LeftProperty, start.X);
                ellipse.Width = end.X - start.X;
            }
            else
            {
                ellipse.SetValue(Canvas.LeftProperty, end.X);
                ellipse.Width = start.X - end.X;
            }

            if (end.Y >= start.Y)
            {
                ellipse.SetValue(Canvas.TopProperty, start.Y - 50);
                ellipse.Height = end.Y - start.Y;
            }
            else
            {
                ellipse.SetValue(Canvas.TopProperty, end.Y - 50);
                ellipse.Height = start.Y - end.Y;
            }

            return ellipse;
        }

        public Line DrawLine(Point start, Point end)
        {
            Line line = new Line()
            {
                Stroke = Brushes.Blue,
                X1 = start.X,
                Y1 = start.Y - 50,
                X2 = end.X,
                Y2 = end.Y - 50
            };

            return line;
        }
    }
}
