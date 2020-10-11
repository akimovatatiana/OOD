using Microsoft.VisualStudio.TestTools.UnitTesting;
using Painter.Enums;
using Painter.Shapes;

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
            int vertexCount = 3;
            var color = Color.Green;
            var regularPolygon = new RegularPolygon(center, radius, vertexCount, color);

            Assert.AreEqual(vertexCount, regularPolygon.GetVertexCount());
            Assert.AreEqual(center, regularPolygon.GetCenter());
            Assert.AreEqual(radius, regularPolygon.GetRadius());
        }
    }
}
