using Painter.Shapes;
using System;
using System.Collections.Generic;

namespace Painter
{
    public class PictureDraft
    {
        private readonly List<Shape> _shapes = new List<Shape>();

        public int ShapeCount
        {
            get { return _shapes.Count; } 
        }

        public void AddShape(Shape shape)
        {
            _shapes.Add(shape);
        }

        public Shape GetShape(int index)
        {
            return (index < 0 || index >= _shapes.Count) ? throw new ArgumentOutOfRangeException("Index out of range") : _shapes[index];
        }
    }
}
