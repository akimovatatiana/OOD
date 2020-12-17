using Slides;
using Slides.Shapes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SlidesTests
{
    public class TestCanvas : ICanvas
    {
        private readonly TextWriter _textWriter;

        public TestCanvas(TextWriter textWriter)
        {
            _textWriter = textWriter;
        }

        public void DrawEllipse(Point center, double w, double h)
        {
            _textWriter.WriteLine($"ellipse with center: {center}; width: {w}; height: {h}");
        }

        public void SetOutlineColor(RGBAColor color)
        {
            throw new NotImplementedException();
        }

        public void SetFillColor(RGBAColor color)
        {
            throw new NotImplementedException();
        }

        public void SetOutlineThickness(uint thickness)
        {
            throw new NotImplementedException();
        }

        public void FillEllipse(Point center, double width, double height)
        {
            throw new NotImplementedException();
        }

        public void FillPolygon(List<Point> vertices)
        {
            throw new NotImplementedException();
        }

        public void DrawLine(Point from, Point to)
        {
            _textWriter.WriteLine($"line from {from}, to {to}");
        }
    }
}
