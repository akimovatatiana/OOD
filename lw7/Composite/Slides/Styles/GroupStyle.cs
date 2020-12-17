using Slides.Styles;
using System.Collections.Generic;
using System.Linq;

namespace Slides
{
    public class GroupStyle<T> : IStyle where T : IStyle
    {
        protected readonly IEnumerable<T> _styles;

        public GroupStyle(IEnumerable<T> styles)
        {
            _styles = styles;
        }

        public void Enable(bool enable)
        {
            foreach (var style in _styles)
            {
                style.Enable(enable);
            }
        }

        public RGBAColor GetColor()
        {
            var firstColor = Enumerable.First(_styles).GetColor();
            foreach (var style in _styles)
            {
                if (style.GetColor() != firstColor)
                {
                    return null;
                }
            }
            return firstColor;
        }

        public bool? IsEnabled()
        {
            var isFirstEnable = Enumerable.First(_styles).IsEnabled();
            foreach (var style in _styles)
            {
                if (style.IsEnabled() != isFirstEnable)
                {
                    return null;
                }
            }
            return isFirstEnable;
        }

        public void SetColor(RGBAColor color)
        {
            foreach (var style in _styles)
            {
                style.SetColor(color);
            }
        }
    }
}