using Microsoft.VisualStudio.TestTools.UnitTesting;
using Painter.Enums;
using Painter.Shapes;
using System.IO;

namespace PainterTests.ShapesTests
{
    [TestClass]
    public class RegularPolygonTests
    {
        [TestMethod]
        public void CanCreateRegularPolygon()
        {
            var center = new Point(5, 5);
            double radius = 10;
            int vertexCount = 6;
            var color = Color.Green;
            var regularPolygon = new RegularPolygon(center, radius, vertexCount, color);

            Assert.AreEqual(color, regularPolygon.Color);
            Assert.AreEqual(vertexCount, regularPolygon.VertexCount);
            Assert.AreEqual(center, regularPolygon.Center);
            Assert.AreEqual(radius, regularPolygon.Radius);
        }

        [TestMethod]
        public void Draw_WithRegularPolygon_ShouldWriteDrawingInfo()
        {
            var center = new Point(100, 100);
            double radius = 30;
            int vertexCount = 3;
            var color = Color.Green;
            var regularPolygon = new RegularPolygon(center, radius, vertexCount, color);
            var sw = new StringWriter();
            var canvas = new TestCanvas(sw);

            regularPolygon.Draw(canvas);

            var expectedString = "Green line from (130, 100), to (85, 125,98076211353316)\r\n" +
            "Green line from (85, 125,98076211353316), to (84,99999999999999, 74,01923788646684)\r\n" +
            "Green line from (84,99999999999999, 74,01923788646684), to (130, 99,99999999999999)\r\n";
            Assert.AreEqual(expectedString, sw.ToString());
        }
    }
}
