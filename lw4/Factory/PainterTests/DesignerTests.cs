using Microsoft.VisualStudio.TestTools.UnitTesting;
using Painter;
using System.IO;

namespace PainterTests
{
    [TestClass]
    public class DesignerTests
    {
        [TestMethod]
        public void CreateDraft_FromStream_WithNoShape_ShouldCreateEmptyDraft()
        {
            var factory = new ShapeFactory();
            var designer = new Designer(factory);

            var inputData = new StringReader("");
            var draft = designer.CreateDraft(inputData);

            Assert.AreEqual(0, draft.ShapeCount);
        }

        [TestMethod]
        public void CreateDraft_FromStream_WithInvalidShape_ShouldCreateDraftWithoutInvalidShape()
        {
            var factory = new ShapeFactory();
            var designer = new Designer(factory);

            var inputData = new StringReader("Line green -2 3 4 3 2 5\nTriangle green -2 3 4 3 2 5");
            var draft = designer.CreateDraft(inputData);
            Assert.AreEqual(1, draft.ShapeCount);
        }

        [TestMethod]
        public void CreateDraft_FromStream_WithOneShape_ShouldCreateDraft()
        {
            var factory = new ShapeFactory();
            var designer = new Designer(factory);

            var inputData = new StringReader("Triangle green -2 3 4 3 2 5");
            var draft = designer.CreateDraft(inputData);

            Assert.AreEqual(1, draft.ShapeCount);
        }

        [TestMethod]
        public void CreateDraft_FromStream_WithMultipleShape_ShouldCreateDraft()
        {
            var factory = new ShapeFactory();
            var designer = new Designer(factory);

            var inputData = new StringReader("Triangle green -2 3 4 3 2 5\nTriangle green -2 3 4 3 2 5");
            var draft = designer.CreateDraft(inputData);
            Assert.AreEqual(2, draft.ShapeCount);
        }
    }
}
