using Microsoft.VisualStudio.TestTools.UnitTesting;
using Painter;
using Painter.Enums;
using System;

namespace PainterTests
{
    [TestClass]
    public class PictureDraftTests
    {
        [TestMethod]
        public void AddShape_WithMultipleShapes_ShouldAddShapesToPictureDraft()
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
        public void CanShape_ByIndex_ShouldGetShape()
        {
            var pictureDraft = new PictureDraft();
            var shape = new TestShape(Color.Blue);

            pictureDraft.AddShape(shape);
            Assert.AreEqual(shape, pictureDraft.GetShape(0));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetShape_ByIndexOutOfRange_ShouldThrowException()
        {
            var pictureDraft = new PictureDraft();
            var shape = new TestShape(Color.Blue);

            pictureDraft.AddShape(shape);
            pictureDraft.GetShape(-1);
            pictureDraft.GetShape(2);
        }
    }
}
