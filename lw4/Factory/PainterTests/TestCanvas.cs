using System.IO;
using Painter.Canvases;
using Painter.Enums;
using Painter.Shapes;

namespace PainterTests
{
    public class TestCanvas : ICanvas
    {
        private readonly TextWriter _textWriter;
        private Color _color;

        public TestCanvas(TextWriter textWriter)
        {
            _textWriter = textWriter;
        }

        public void SetColor(Color color)
        {
            _color = color;
        }

        public void DrawLine(Point from, Point to)
        {
            _textWriter.WriteLine($"{ColorToString()} line from {from}, to {to}");
        }

        public void DrawEllipse(Point center, double w, double h)
        {
            _textWriter.WriteLine($"{ColorToString()} ellipse with center: {center}; width: {w}; height: {h}");
        }

        private string ColorToString()
        {
            return _color switch
            {
                Color.Green => "Green",
                Color.Red => "Red",
                Color.Blue => "Blue",
                Color.Yellow => "Yellow",
                Color.Pink => "Pink",
                Color.Black => "Black",
                _ => "Black",
            };
        }
    }
}
