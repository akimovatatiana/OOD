using Microsoft.VisualStudio.TestTools.UnitTesting;
using Painter.Enums;
using Painter.Shapes;
using System.IO;

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
        public void Draw_WithRectangle_ShouldWriteDrawingInfo()
        {
            var leftTop = new Point(3, 5);
            var rightBottom = new Point(10, 3);
            var color = Color.Green;
            var rectangle = new Rectangle(leftTop, rightBottom, color);
            var sw = new StringWriter();
            var canvas = new TestCanvas(sw);

            rectangle.Draw(canvas);

            var expectedString = "Green line from (3, 5), to (10, 5)\r\n" +
            "Green line from (10, 5), to (10, 3)\r\n" +
            "Green line from (10, 3), to (3, 3)\r\n" +
            "Green line from (3, 3), to (3, 5)\r\n";
            Assert.AreEqual(expectedString, sw.ToString());
        }
    }
}
