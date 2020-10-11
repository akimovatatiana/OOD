using Microsoft.VisualStudio.TestTools.UnitTesting;
using Painter.Enums;
using Painter.Shapes;

namespace PainterTests.ShapesTests
{
    [TestClass]
    public class RectangleTests
    {
        [TestMethod]
        public void CanCreateRectangle()
        {
            var leftTop = new Point(3, 5);
            var rightBottom = new Point(10, 3);
            var color = Color.Green;
            var rectangle = new Rectangle(leftTop, rightBottom, color);

            Assert.AreEqual(leftTop, rectangle.GetLeftTop());
            Assert.AreEqual(rightBottom, rectangle.GetRightBottom());
        }

        [TestMethod]
        public void CanDrawRectangle()
        {
        }
    }
}
