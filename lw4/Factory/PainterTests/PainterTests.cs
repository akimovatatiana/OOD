using Microsoft.VisualStudio.TestTools.UnitTesting;
using Painter;
using Painter.Enums;
using Painter.Shapes;
using System.IO;

namespace PainterTests
{
    [TestClass]
    public class PainterTests
    {
        [TestMethod]
        public void DrawPicture_WithShapeAndCanvas_ShouldDrawPicture()
        {
            var painter = new Painter.Painter();
            var pictureDraft = new PictureDraft();
            var rectangle = new Rectangle(new Point(150, 150), new Point(10, 300), Color.Blue);
            var ellipse = new Ellipse(new Point(200, 200), 100, 75, Color.Yellow);
            var sw = new StringWriter();
            var canvas = new TestCanvas(sw);

            pictureDraft.AddShape(rectangle);
            pictureDraft.AddShape(ellipse);
            painter.DrawPicture(pictureDraft, canvas);

            string expected = "Blue line from (150, 150), to (10, 150)\r\n" +
            "Blue line from (10, 150), to (10, 300)\r\n" +
            "Blue line from (10, 300), to (150, 300)\r\n" +
            "Blue line from (150, 300), to (150, 150)\r\n" +
            "Yellow ellipse with center: (200, 200); width: 200; height: 150\r\n";
            Assert.AreEqual(expected, sw.ToString());
        }
    }
}
