using Painter.Shapes;
using Color = Painter.Enums.Color;

namespace Painter
{
    public interface ICanvas
    {
        Color Color { get; set; }
        void DrawLine(Point from, Point to);
        void DrawEllipse(Point center, double w, double h);
    }
}
