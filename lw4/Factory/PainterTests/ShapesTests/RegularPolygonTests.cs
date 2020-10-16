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

            Assert.AreEqual(vertexCount, regularPolygon.GetVertexCount());
            Assert.AreEqual(center, regularPolygon.GetCenter());
            Assert.AreEqual(radius, regularPolygon.GetRadius());
        }

        [TestMethod]
        public void Draw_WithRegularPolygon_ShouldWriteDrawingInfo()
        {
            var center = new Point(0, 0);
            double radius = 4;
            int vertexCount = 5;
            var color = Color.Green;
            var regularPolygon = new RegularPolygon(center, radius, vertexCount, color);
            var sw = new StringWriter();
            var canvas = new TestCanvas(sw);

            regularPolygon.Draw(canvas);

            var expectedString = "";
            Assert.AreEqual(expectedString, sw.ToString());
        }
    }
}
