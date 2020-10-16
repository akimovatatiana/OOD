using Painter.Enums;

namespace Painter.Shapes
{
    public class Triangle : Shape
    {
        public Point Vertex1 { get; }
        public Point Vertex2 { get; }
        public Point Vertex3 { get; }

        public Triangle(Point vertex1, Point vertex2, Point vertex3, Color color)
            : base(color)
        {
            Vertex1 = vertex1;
            Vertex2 = vertex2;
            Vertex3 = vertex3;
        }

        public override void Draw(ICanvas canvas)
        {
            canvas.Color = Color;
            canvas.DrawLine(Vertex1, Vertex2);
            canvas.DrawLine(Vertex2, Vertex3);
            canvas.DrawLine(Vertex3, Vertex1);
        }
    }
}
