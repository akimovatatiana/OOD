using Painter;
using System;
using System.Windows.Media;
using System.Windows.Shapes;
using Color = Painter.Enums.Color;

namespace PainterVisualization
{
    public class Canvas : ICanvas
    {
        public Color Color { get; set; }
        private readonly System.Windows.Controls.Canvas _canvas;

        public Canvas(System.Windows.Controls.Canvas canvas)
        {
            _canvas = canvas;
        }

        public void DrawLine(Painter.Shapes.Point from, Painter.Shapes.Point to)
        {
            var line = new Line
            {
                X1 = from.X,
                Y1 = from.Y,
                X2 = to.X,
                Y2 = to.Y,
                Stroke = ToColor()
            };
            _canvas.Children.Add(line);
        }

        public void DrawEllipse(Painter.Shapes.Point center, double w, double h)
        {
            var ellipse = new Ellipse
            {
                Width = w,
                Height = h,
                Stroke = ToColor(),
            };
            System.Windows.Controls.Canvas.SetLeft(ellipse, center.X - w / 2);
            System.Windows.Controls.Canvas.SetTop(ellipse, center.Y - h / 2);
            _canvas.Children.Add(ellipse); 
        }

        private SolidColorBrush ToColor()
        {
            return Color switch
            {
                Color.Green => Brushes.Green,
                Color.Red => Brushes.Red,
                Color.Blue => Brushes.Blue,
                Color.Yellow => Brushes.Yellow,
                Color.Pink => Brushes.Pink,
                Color.Black => Brushes.Black,
                _ => throw new Exception("Incorrect color. You can choose color from [green, red, blue, yellow, pink, black]")
            };
        }
    }
    
}
