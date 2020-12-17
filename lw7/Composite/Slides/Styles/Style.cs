namespace Slides.Styles
{
    public class Style : IStyle
    {
        private RGBAColor _color;
        private bool _isEnabled;

        public Style()
        {
        }
        
        public Style(RGBAColor color, bool isEnabled)
        {
            _color = color;
            _isEnabled = isEnabled;
        }

        public void Enable(bool enable)
        {
            _isEnabled = enable;
        }

        public RGBAColor GetColor()
        {
            return _color;
        }

        public bool? IsEnabled()
        {
            return _isEnabled;
        }

        public void SetColor(RGBAColor color)
        {
            _color = color;
        }
    }
}
