using Painter.Shapes;
using Color = Painter.Enums.Color;

namespace Painter.Canvases
{
    public interface ICanvas
    {
        void SetColor(Color color);
        //Color Color { get; set; }
        void DrawLine(Point from, Point to);
        void DrawEllipse(Point center, double w, double h);
    }
}
