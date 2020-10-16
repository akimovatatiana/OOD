using Painter.Enums;
using System;

namespace Painter.Shapes
{
    public class RegularPolygon : Shape
    {
        public Point Center { get; }
        public double Radius { get; }
        public int VertexCount { get; }

        public RegularPolygon(Point center, double radius, int vertexCount, Color color)
            : base(color)
        {
            Center = center;
            Radius = radius;
            VertexCount = vertexCount;
        }

        public override void Draw(ICanvas canvas)
        {
            canvas.Color = Color;
            double angle = 2 * Math.PI / VertexCount;

            var startPoint = new Point(Center.X + Radius * Math.Cos(0), Center.Y);

            for (int i = 0; i <= VertexCount; i++)
            {
                var endPoint = new Point(Center.X + Radius * Math.Cos(angle * i), Center.Y + Radius * Math.Sin(angle * i));
                canvas.DrawLine(startPoint, endPoint);
                startPoint = endPoint;
            }
        }
    }
}
