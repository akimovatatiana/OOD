namespace Slides.Styles
{
    public interface IStyle
    {
        bool? IsEnabled();
        void Enable(bool enable);
        RGBAColor GetColor();
        void SetColor(RGBAColor color);
    }
}
