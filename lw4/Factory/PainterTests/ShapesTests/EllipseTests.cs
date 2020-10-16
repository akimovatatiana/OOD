using Microsoft.VisualStudio.TestTools.UnitTesting;
using Painter.Enums;
using Painter.Shapes;
using System.IO;

namespace PainterTests.ShapesTests
{
    [TestClass]
    public class EllipseTests
    {
        [TestMethod]
        public void CanCreateEllipse()
        {
            var center = new Point(5, 5);
            double horizontalRadius = 6;
            double verticalRadius = 2;
            var color = Color.Green;
            var ellipse = new Ellipse(center, horizontalRadius, verticalRadius, color);
            
            Assert.AreEqual(color, ellipse.Color);
            Assert.AreEqual(center, ellipse.Center);
            Assert.AreEqual(horizontalRadius, ellipse.HorizontalRadius);
            Assert.AreEqual(verticalRadius, ellipse.VerticalRadius);
        }

        [TestMethod]
        public void Draw_WithEllipse_ShouldWriteDrawingInfo()
        {
            var center = new Point(5, 5);
            double horizontalRadius = 6;
            double verticalRadius = 2;
            var color = Color.Green;
            var ellipse = new Ellipse(center, horizontalRadius, verticalRadius, color);
            var sw = new StringWriter();

            var canvas = new TestCanvas(sw);

            ellipse.Draw(canvas);
            var expectedString = $"Green ellipse with center: {center}; width: {horizontalRadius * 2}; height: {verticalRadius * 2}\r\n";

            Assert.AreEqual(expectedString, sw.ToString());
        }
    }
}
