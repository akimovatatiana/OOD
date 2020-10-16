using Painter;
using Painter.Enums;
using Painter.Shapes;

namespace PainterTests
{
    public class TestShape : Shape
    {
        public TestShape(Color color)
            : base(color)
        {
        }

        public override void Draw(ICanvas canvas)
        {
        }
    }
}
