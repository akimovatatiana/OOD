using Slides.Styles;

namespace Slides.Shapes
{
    public interface IShape : IDrawable
    {
        Rect<double>? GetFrame();
        void SetFrame(Rect<double> rect);
        IOutlineStyle GetOutlineStyle();
        IStyle GetFillStyle();
    }
}
