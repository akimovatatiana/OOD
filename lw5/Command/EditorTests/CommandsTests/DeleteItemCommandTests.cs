using Editor;
using Editor.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace EditorTests.CommandsTests
{
    [TestClass]
    public class DeleteItemCommandTests
    {
        [TestMethod]
        public void Execute_DeleteItemCommand_WithPosition_ShouldRemoveItemFromItemsList()
        {
            var documentItems = new List<DocumentItem>
            { 
                new DocumentItem(new TestParagraph()),
                new DocumentItem(new TestParagraph())
            };
            var command = new DeleteItemCommand(documentItems, 1);
            command.Execute();

            Assert.AreEqual(1, documentItems.Count);
        }

        [TestMethod]
        public void Unexecute_DeleteItemCommand_WithPosition_ShouldRemoveItemFromItemsList()
        {
            var documentItems = new List<DocumentItem>
            {
                new DocumentItem(new TestParagraph()),
                new DocumentItem(new TestParagraph())
            };
            var command = new DeleteItemCommand(documentItems, 1);
            command.Execute();
            Assert.AreEqual(1, documentItems.Count);

            command.Unexecute();
            Assert.AreEqual(2, documentItems.Count);
        }
    }
}
