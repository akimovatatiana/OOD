using Painter.Canvases;
using Painter.Enums;
using System;

namespace Painter.Shapes
{
    public class RegularPolygon : Shape
    {
        private Point _center;
        private double _radius;
        private int _vertexCount;

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
            throw new NotImplementedException();
        }
    }
}
