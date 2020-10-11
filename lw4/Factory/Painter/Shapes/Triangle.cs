using Painter.Canvases;
using Painter.Enums;
using System;

namespace Painter.Shapes
{
    public class Triangle : Shape
    {
        private Point _vertex1;
        private Point _vertex2;
        private Point _vertex3;

        public Triangle(Point vertex1, Point vertex2, Point vertex3, Color color)
            : base(color)
        {
            _vertex1 = vertex1;
            _vertex2 = vertex2;
            _vertex3 = vertex3;
        }

        public Point GetVertex1()
        {
            return _vertex1;
        }

        public Point GetVertex2()
        {
            return _vertex2;
        }

        public Point GetVertex3()
        {
            return _vertex3;
        }

        public override void Draw(ICanvas canvas)
        {
            throw new NotImplementedException();
        }
    }
}
