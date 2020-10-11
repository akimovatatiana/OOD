using Painter.Canvases;
using Painter.Enums;

namespace Painter.Shapes
{
    public class Rectangle : Shape
    {
        private Point _leftTop;
        private Point _rightBottom;

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
            throw new System.NotImplementedException();
        }
    }
}
