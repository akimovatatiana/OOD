using Slides.Styles;
using System;

namespace Slides.Shapes
{
    public abstract class Shape : IShape
    {
        protected Rect<double> _frame;
        protected IOutlineStyle _outlineStyle;
        protected IStyle _fillStyle;

        public Shape(Rect<double> frame, IOutlineStyle outlineStyle = null, IStyle fillStyle = null)
        {
            _frame = frame;
            _outlineStyle = outlineStyle ?? new OutlineStyle();
            _fillStyle = fillStyle ?? new Style();
        }

        public abstract void Draw(ICanvas canvas);

        public IStyle GetFillStyle()
        {
            return _fillStyle;
        }

        public Rect<double>? GetFrame()
        {
            return _frame;
        }

        public IOutlineStyle GetOutlineStyle()
        {
            return _outlineStyle;
        }

        public void SetFrame(Rect<double> rect)
        {
            if (rect.Height >= 0 && rect.Width >= 0)
            {
                _frame = rect;
            }
            else
            {
                throw new ArgumentException("Frame height and width must be more than 0");
            }
        }
    }
}
