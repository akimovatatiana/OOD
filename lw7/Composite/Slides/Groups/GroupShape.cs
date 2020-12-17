using Slides.Shapes;
using Slides.Styles;
using System;
using System.Collections.Generic;

namespace Slides.Groups
{
    public class GroupShape : IShape
    {
        private readonly List<IShape> _shapes;
        private readonly GroupStyle<IStyle> _fillStyle;
        private readonly GroupOutlineStyle _outlineStyle;

        public GroupShape()
        {
            _shapes = new List<IShape>();
            _fillStyle = new GroupStyle<IStyle>(GetGroupFillStyle());
            _outlineStyle = new GroupOutlineStyle(GetGroupOutlineStyle());
        }

        private IEnumerable<IOutlineStyle> GetGroupOutlineStyle()
        {
            foreach (var shape in _shapes)
            {
                yield return shape.GetOutlineStyle();
            }
        }

        private IEnumerable<IStyle> GetGroupFillStyle()
        {
            foreach (var shape in _shapes)
            {
                yield return shape.GetFillStyle();
            }
        }

        public void SetFrame(Rect<double> frame)
        {
            if (frame.Height > 0 && frame.Width > 0)
            {
                if (ShapesCount > 0 && GetFrame().HasValue)
                {
                    var oldFrame = GetFrame().Value;
                    foreach (var shape in _shapes)
                    {
                        var shapeFrame = shape.GetFrame();
                        var newFrame = new Rect<double> (
                            frame.Left + (shapeFrame.Value.Left - oldFrame.Left) * frame.Width / oldFrame.Width,
                            frame.Top + (shapeFrame.Value.Top - oldFrame.Top) * frame.Height / oldFrame.Height,
                            shapeFrame.Value.Width * frame.Width / oldFrame.Width,
                            shapeFrame.Value.Height * frame.Height / oldFrame.Height);
                        shape.SetFrame(newFrame);
                    }
                }
            }
            else
            {
                throw new ArgumentException("Frame height and width must be more than 0");
            }
        }

        public Rect<double>? GetFrame()
        {
            if (ShapesCount <= 0)
            {
                return null;
            }
            bool wasNotNullFrame = false;
            double left = double.MaxValue;
            double top = double.MaxValue;
            double width = double.MinValue;
            double height = double.MinValue;

            foreach (var shape in _shapes)
            {
                var shapeFrame = shape.GetFrame().Value;
                left = Math.Min(left, shapeFrame.Left);
                top = Math.Min(top, shapeFrame.Top);
                width = Math.Max(width, shapeFrame.Width);
                height = Math.Max(height, shapeFrame.Height);
            }
            return new Rect<double>(left, top, width - left, height - top);
        }

        private Rect<double>? CalculateShapesFrame()
        {
            bool wasNotNullFrame = false;
            double left = double.MaxValue;
            double top = double.MaxValue;
            double maxXCor = double.MinValue;
            double maxYCor = double.MinValue;

            foreach (var shape in _shapes)
            {
                if (shape.GetFrame() == null)
                {
                    continue;
                }
                wasNotNullFrame = true;
                left = shape.GetFrame().Value.Left.CompareTo(left) > 0 ? left : shape.GetFrame().Value.Left;
                top = shape.GetFrame().Value.Top.CompareTo(top) > 0 ? top : shape.GetFrame().Value.Top;

                var xCor = shape.GetFrame().Value.Left + shape.GetFrame().Value.Width;
                var yCor = shape.GetFrame().Value.Top + shape.GetFrame().Value.Height;

                maxXCor = maxXCor.CompareTo(xCor) > 0 ? maxXCor : xCor;
                maxYCor = maxYCor.CompareTo(yCor) > 0 ? maxYCor : yCor;
            }

            return wasNotNullFrame ? (Rect<double>?)new Rect<double>(left, top, maxXCor - left, maxYCor - top) : null;
        }

        public IOutlineStyle GetOutlineStyle()
        {
            return _outlineStyle;
        }

        public IStyle GetFillStyle()
        {
            return _fillStyle;
        }

        public void Draw(ICanvas canvas)
        {
            foreach (var shape in _shapes)
            {
                shape.Draw(canvas);
            }
        }

        public void InsertShape(IShape shape, int position = 0)
        {
            if (position >= 0 && position <= ShapesCount)
            {
                _shapes.Insert(position, shape);
            }
        }

        public IShape GetShapeAtIndex(int index)
        {
            return IsIndexInRange(index) ? _shapes[index] : throw new IndexOutOfRangeException();
        }

        public void RemoveShapeAtIndex(int index)
        {
            if (IsIndexInRange(index))
            {
                _shapes.RemoveAt(index);
            }
        }

        public int ShapesCount => _shapes.Count;

        private bool IsIndexInRange(int index)
        {
            return index >= 0 && index < ShapesCount;
        }
    }
}
