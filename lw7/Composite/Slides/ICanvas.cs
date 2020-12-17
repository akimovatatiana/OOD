using Slides.Shapes;
using System.Collections.Generic;

namespace Slides
{
    public interface ICanvas
    {
        void SetOutlineColor(RGBAColor color);
        void SetFillColor(RGBAColor color);
        void SetOutlineThickness(uint thickness);
        void FillEllipse(Point center, double width, double height);
        void FillPolygon(List<Point> vertices);
        void DrawEllipse(Point center, double width, double height);
        void DrawLine(Point from, Point to);
    }
}
