using Painter.Enums;

namespace Painter.Shapes
{
    public class Ellipse : Shape
    {
        public Point Center { get; }
        public double HorizontalRadius { get; }
        public double VerticalRadius { get; }

        public Ellipse(Point center, double horizontalRadius, double verticalRadius, Color color)
            : base(color)
        {
            Center = center;
            HorizontalRadius = horizontalRadius;
            VerticalRadius = verticalRadius;
        }

        public override void Draw(ICanvas canvas)
        {
            canvas.Color = Color;
            canvas.DrawEllipse(Center, HorizontalRadius * 2, VerticalRadius * 2);
        }
    }
}
