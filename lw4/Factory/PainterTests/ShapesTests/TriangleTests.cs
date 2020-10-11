using Microsoft.VisualStudio.TestTools.UnitTesting;
using Painter.Enums;
using Painter.Shapes;

namespace PainterTests.ShapesTests
{
    [TestClass]
    public class TriangleTests
    {
        [TestMethod]
        public void CanCreateTriangle()
        {
            var vertex1 = new Point(-2, 3);
            var vertex2 = new Point(4, 3);
            var vertex3 = new Point(2, 5);
            var color = Color.Red;
            var triangle = new Triangle(vertex1, vertex2, vertex3, color);

            Assert.AreEqual(vertex1, triangle.GetVertex1());
            Assert.AreEqual(vertex2, triangle.GetVertex2());
            Assert.AreEqual(vertex3, triangle.GetVertex3());
        }

        [TestMethod]
        public void CanDrawTriangle()
        {
        }
    }
}
