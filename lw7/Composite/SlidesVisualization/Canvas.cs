using Slides;
using Slides.Shapes;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SlidesVisualization
{
    public class Canvas : ICanvas
    {
        private readonly System.Windows.Controls.Canvas _canvas;
        private SolidColorBrush _outlineColor;
        private SolidColorBrush _fillColor;
        private uint _thickness;

        public Canvas(System.Windows.Controls.Canvas canvas)
        {
            _canvas = canvas;
            _fillColor = new SolidColorBrush(Colors.Transparent);
            _outlineColor = new SolidColorBrush(Colors.Black);
            _thickness = 1;
        }

        public void SetFillColor(RGBAColor color)
        {
            Color c = new Color
            {
                R = (byte)color.R,
                G = (byte)color.G,
                B = (byte)color.B,
                A = (byte)color.A
            };
            _fillColor = new SolidColorBrush(c);
        }

        public void SetOutlineColor(RGBAColor color)
        {
            Color c = new Color
            {
                R = (byte)color.R,
                G = (byte)color.G,
                B = (byte)color.B,
                A = (byte)color.A
            };
            _outlineColor = new SolidColorBrush(c);
        }

        public void DrawLine(Point from, Point to)
        {
            var line = new Line
            {
                X1 = from.X,
                Y1 = from.Y,
                X2 = to.X,
                Y2 = to.Y,
                Stroke = _outlineColor,
                StrokeThickness = _thickness
            };
            _canvas.Children.Add(line);
        }

        public void SetOutlineThickness(uint thickness)
        {
            _thickness = thickness;
        }

        public void FillEllipse(Point center, double width, double height)
        {
            var ellipse = new System.Windows.Shapes.Ellipse
            {
                Width = width,
                Height = height,
                Fill = _fillColor,
            };
            System.Windows.Controls.Canvas.SetLeft(ellipse, center.X - width / 2);
            System.Windows.Controls.Canvas.SetTop(ellipse, center.Y - height / 2);
            _canvas.Children.Add(ellipse);
        }

        public void FillPolygon(List<Point> vertices)
        {
            var polygon = new Polygon
            {
                Points = new PointCollection(vertices.Select(point => new System.Windows.Point(point.X, point.Y))),
                Fill = _fillColor
            };
            _canvas.Children.Add(polygon);
        }

        public void DrawEllipse(Point center, double width, double height)
        {
            var ellipse = new System.Windows.Shapes.Ellipse
            {
                Width = width,
                Height = height,
                Stroke = _outlineColor,
            };
            System.Windows.Controls.Canvas.SetLeft(ellipse, center.X - width / 2);
            System.Windows.Controls.Canvas.SetTop(ellipse, center.Y - height / 2);
            _canvas.Children.Add(ellipse);
        }
    }
}
