using Microsoft.VisualStudio.TestTools.UnitTesting;
using Painter;
using System.IO;

namespace PainterTests
{
    [TestClass]
    public class DesignerTests
    {
        [TestMethod]
        public void CanCreateDraft_FromStream_WithOneShape()
        {
            var factory = new ShapeFactory();
            var designer = new Designer(factory);

            var inputData = new StringReader("Triangle green -2 3 4 3 2 5");
            var draft = designer.CreateDraft(inputData);

            Assert.AreEqual(1, draft.GetShapeCount());
        }

        [TestMethod]
        public void CreateDraft_FromStream_WithMultipleShape()
        {
            var factory = new ShapeFactory();
            var designer = new Designer(factory);

            var inputData = new StringReader("Triangle green -2 3 4 3 2 5\nTriangle green -2 3 4 3 2 5");
            var draft = designer.CreateDraft(inputData);
            Assert.AreEqual(2, draft.GetShapeCount());
        }
    }
}
