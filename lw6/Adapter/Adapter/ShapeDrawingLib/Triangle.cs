using Adapter.GraphicsLib;

namespace Adapter.ShapeDrawingLib
{
    public class Triangle : ICanvasDrawable
    {
        private readonly Point _vertex1;
        private readonly Point _vertex2;
        private readonly Point _vertex3;
        private readonly uint _color;

        public Triangle(Point vertex1, Point vertex2, Point vertex3, uint color = 0x000000)
        {
            _vertex1 = vertex1;
            _vertex2 = vertex2;
            _vertex3 = vertex3;
            _color = color;
        }

        public void Draw(ICanvas canvas)
        {
            canvas.SetColor(_color);
            canvas.MoveTo(_vertex1.X, _vertex1.Y);
            canvas.LineTo(_vertex2.X, _vertex2.Y);
            canvas.LineTo(_vertex3.X, _vertex3.Y);
            canvas.LineTo(_vertex1.X, _vertex1.Y);
        }
    }
}
