using Microsoft.VisualStudio.TestTools.UnitTesting;
using Painter.Enums;
using Painter.Shapes;
using System.IO;

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
        public void Draw_WithTriangle_ShouldWriteDrawingInfo()
        {
            var vertex1 = new Point(-2, 3);
            var vertex2 = new Point(4, 3);
            var vertex3 = new Point(2, 5);
            var color = Color.Green;
            var triangle = new Triangle(vertex1, vertex2, vertex3, color);
            var sw = new StringWriter();

            var canvas = new TestCanvas(sw);

            triangle.Draw(canvas);
            var expectedString = $"Green line from {vertex1}, to {vertex2}\r\nGreen line from {vertex2}, to {vertex3}\r\nGreen line from {vertex3}, to {vertex1}\r\n";

            Assert.AreEqual(expectedString, sw.ToString());
        }
    }
}
