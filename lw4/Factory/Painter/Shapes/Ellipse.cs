using Painter.Canvases;
using Painter.Enums;

namespace Painter.Shapes
{
    public class Ellipse : Shape
    {
        private Point _center;
        private double _horisontalRadius;
        private double _verticalRadius;

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
        }
    }
}
