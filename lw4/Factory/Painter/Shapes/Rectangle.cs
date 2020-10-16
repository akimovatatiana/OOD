using Painter.Enums;

namespace Painter.Shapes
{
    public class Rectangle : Shape
    {
        public Point LeftTop { get; }
        public Point RightBottom { get; }

        public Rectangle(Point leftTop, Point rightBottom, Color color)
            : base(color)
        {
            LeftTop = leftTop;
            RightBottom = rightBottom;
        }

        public override void Draw(ICanvas canvas)
        {
            var rightTop = new Point(RightBottom.X, LeftTop.Y);
            var leftBottom = new Point(LeftTop.X, RightBottom.Y);

            canvas.Color = Color;
            canvas.DrawLine(LeftTop, rightTop);
            canvas.DrawLine(rightTop, RightBottom);
            canvas.DrawLine(RightBottom, leftBottom);
            canvas.DrawLine(leftBottom, LeftTop);
        }
    }
}
