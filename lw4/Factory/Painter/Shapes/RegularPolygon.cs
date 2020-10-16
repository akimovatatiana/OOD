using Painter.Canvases;
using Painter.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Painter.Shapes
{
    public class RegularPolygon : Shape
    {
        private readonly Point _center;
        private readonly double _radius;
        private readonly int _vertexCount;

        public RegularPolygon(Point center, double radius, int vertexCount, Color color)
            : base(color)
        {
            _center = center;
            _radius = radius;
            _vertexCount = vertexCount;
        }

        public int GetVertexCount()
        {
            return _vertexCount;
        }

        public Point GetCenter()
        {
            return _center;
        }

        public double GetRadius()
        {
            return _radius;
        }

        public override void Draw(ICanvas canvas)
        {
            canvas.SetColor(GetColor());
            double angle = 2 * Math.PI / _vertexCount;

            var startPoint = new Point(_center.X + _radius * Math.Cos(0), _center.Y);

            for (int i = 0; i < _vertexCount; i++)
            {
                var endPoint = new Point(_center.X + _radius * Math.Cos(angle * i), _center.Y + _radius * Math.Sin(angle * i));
                canvas.DrawLine(startPoint, endPoint);
                startPoint = endPoint;
            }
        }
    }
}
