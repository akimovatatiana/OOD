using Painter.Canvases;
using Painter.Enums;

namespace Painter.Shapes
{
    public class Rectangle : Shape
    {
        private readonly Point _leftTop;
        private readonly Point _rightBottom;

        public Rectangle(Point leftTop, Point rightBottom, Color color)
            : base(color)
        {
            _leftTop = leftTop;
            _rightBottom = rightBottom;
        }

        public Point GetLeftTop()
        {
            return _leftTop;
        }

        public Point GetRightBottom()
        {
            return _rightBottom;
        }

        public override void Draw(ICanvas canvas)
        {
            var rightTop = new Point(_rightBottom.X, _leftTop.Y);
            var leftBottom = new Point(_leftTop.X, _rightBottom.Y);

            canvas.SetColor(GetColor());
            canvas.DrawLine(_leftTop, rightTop);
            canvas.DrawLine(rightTop, _rightBottom);
            canvas.DrawLine(_rightBottom, leftBottom);
            canvas.DrawLine(leftBottom, _leftTop);
        }
    }
}
