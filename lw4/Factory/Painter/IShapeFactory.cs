using Painter.Shapes;

namespace Painter
{
    public interface IShapeFactory
    {
        Shape CreateShape(string description);
    }
}
