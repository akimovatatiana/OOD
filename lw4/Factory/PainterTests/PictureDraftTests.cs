using Microsoft.VisualStudio.TestTools.UnitTesting;
using Painter;
using Painter.Canvases;
using Painter.Enums;
using Painter.Shapes;
using System;

namespace PainterTests
{
    public class TestShape : Shape
    {
        public TestShape(Color color)
            : base(color)
        {
        }

        public override void Draw(ICanvas canvas)
        {
        }
    }

    [TestClass]
    public class PictureDraftTests
    {
        [TestMethod]
        public void PictureDraft_CanAddShapes()
        {
            var pictureDraft = new PictureDraft();
            var shape1 = new TestShape(Color.Blue);
            var shape2 = new TestShape(Color.Green);

            Assert.AreEqual(0, pictureDraft.ShapeCount);
            pictureDraft.AddShape(shape1);
            pictureDraft.AddShape(shape2);
            Assert.AreEqual(2, pictureDraft.ShapeCount);
        }

        [TestMethod]
        public void PictureDraft_CanGetShapeByIndex()
        {
            var pictureDraft = new PictureDraft();
            var shape = new TestShape(Color.Blue);

            pictureDraft.AddShape(shape);
            Assert.AreEqual(shape, pictureDraft.GetShape(0));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PictureDraft_GetShapeByIndexOutOfRange_ThrowsException()
        {
            var pictureDraft = new PictureDraft();
            var shape = new TestShape(Color.Blue);

            pictureDraft.AddShape(shape);
            pictureDraft.GetShape(-1);
            pictureDraft.GetShape(2);
        }
    }
}
