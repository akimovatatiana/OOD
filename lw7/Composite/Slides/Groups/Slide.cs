using Slides.Shapes;
using System;
using System.Collections.Generic;

namespace Slides.Groups
{
    public class Slide
    {
        private readonly double _width;
        private readonly double _height;
        private RGBAColor _backgroundColor;
        private readonly List<IShape> _shapes;

        public Slide(double width, double height, RGBAColor color)
        {
            _width = width;
            _height = height;
            _backgroundColor = color;
            _shapes = new List<IShape>();
        }

        public int ShapesCount => _shapes.Count;

        public void Draw(ICanvas canvas)
        {
            FillBackgound(canvas);
            foreach (var shape in _shapes)
            {
                shape.Draw(canvas);
            }
        }

        private void FillBackgound(ICanvas canvas)
        {
            canvas.SetFillColor(_backgroundColor);

            var points = new List<Point>
            {
                new Point(0, 0),
                new Point(0, _height),
                new Point(_width, _height),
                new Point(_width, 0)
            };
            canvas.FillPolygon(points);
        }

        public RGBAColor GetBackgroudColor()
        {
            return _backgroundColor;
        }

        public double GetHeight()
        {
            return _height;
        }

        public IShape GetShapeAtIndex(int index)
        {
            return index >= 0 && index < ShapesCount ? _shapes[index] : throw new IndexOutOfRangeException();
        }

        public double GetWidth()
        {
            return _width;
        }

        public void InsertShape(IShape shape, int index = 0)
        {
            if (index >= 0)
            {
                _shapes.Insert(index, shape);
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void RemoveShapeAtIndex(int index)
        {
            if (index >= 0 && index < ShapesCount)
            {
                _shapes.RemoveAt(index);
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void SetBackgroundColor(RGBAColor color)
        {
            _backgroundColor = color;
        }
    }
}
