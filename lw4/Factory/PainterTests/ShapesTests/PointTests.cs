using Microsoft.VisualStudio.TestTools.UnitTesting;
using Painter.Shapes;

namespace PainterTests.ShapesTests
{
    [TestClass]
    public class PointTests
    {
        [TestMethod]
        public void CanCreatePoint()
        {
            var x = 3.5;
            var y = 4.6;
            var point = new Point(x, y);

            Assert.AreEqual(x, point.X);
            Assert.AreEqual(y, point.Y);
        }
    }
}
