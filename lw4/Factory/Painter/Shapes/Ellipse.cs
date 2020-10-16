using Painter.Canvases;
using Painter.Enums;

namespace Painter.Shapes
{
    public class Ellipse : Shape
    {
        private readonly Point _center;
        private readonly double _horisontalRadius;
        private readonly double _verticalRadius;

        public Ellipse(Point center, double horisontalRadius, double verticalRadius, Color color)
            : base(color)
        {
            _center = center;
            _horisontalRadius = horisontalRadius;
            _verticalRadius = verticalRadius;
        }

        public Point GetCenter()
        {
            return _center;
        }

        public double GetHorizontalRadius()
        {
            return _horisontalRadius;
        }

        public double GetVerticalRadius()
        {
            return _verticalRadius;
        }

        public override void Draw(ICanvas canvas)
        {
            canvas.SetColor(GetColor());
            canvas.DrawEllipse(_center, _horisontalRadius * 2, _verticalRadius * 2);
        }
    }
}
