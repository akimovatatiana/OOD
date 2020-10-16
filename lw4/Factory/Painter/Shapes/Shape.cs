using Painter.Enums;

namespace Painter.Shapes
{
    public abstract class Shape
    {
        public Color Color { get; }

        public Shape(Color color)
        {
            Color = color;
        }

        public abstract void Draw(ICanvas canvas);
    }
}
