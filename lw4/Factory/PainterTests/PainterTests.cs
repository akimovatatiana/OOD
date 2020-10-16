using Microsoft.VisualStudio.TestTools.UnitTesting;
using Painter;
using Painter.Canvases;
using System;
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
            var shape = new TestShape(Painter.Enums.Color.Green);
            var canvas = new Canvas();

            pictureDraft.AddShape(shape);

            var sw = new StringWriter();
            Console.SetOut(sw);

            painter.DrawPicture(pictureDraft, canvas);

            string result = sw.ToString();
            string expected = "Shape: TestShape\n";
            Assert.AreEqual(expected, result);
        }
    }
}
