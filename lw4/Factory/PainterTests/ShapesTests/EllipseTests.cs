using Microsoft.VisualStudio.TestTools.UnitTesting;
using Painter.Enums;
using Painter.Shapes;

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

            Assert.AreEqual(center, ellipse.GetCenter());
            Assert.AreEqual(horizontalRadius, ellipse.GetHorizontalRadius());
            Assert.AreEqual(verticalRadius, ellipse.GetVerticalRadius());
        }

        [TestMethod]
        public void CanDrawEllipse()
        {

        }
    }
}
