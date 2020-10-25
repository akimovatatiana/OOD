using Editor;
using Editor.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace EditorTests.CommandsTests
{
    [TestClass]
    public class InsertParagraphCommandTests
    {
        [TestMethod]
        public void Execute_InsertParagraphCommand_WithEndPosition_ShouldInsertParagraphToTheEnd()
        {
            var documentItems = new List<DocumentItem>()
            { 
                new DocumentItem(new Paragraph()),
                new DocumentItem(new Paragraph())
            };
            var paragraph = new Paragraph();
            var command = new InsertParagraphCommand(documentItems, paragraph, null);
            command.Execute();
            Assert.AreEqual(paragraph, documentItems[2].Paragraph);
        }

        [TestMethod]
        public void Execute_InsertParagraphCommand_WithSettedPosition_ShouldInsertParagraph()
        {
            var documentItems = new List<DocumentItem>()
            {
                new DocumentItem(new Paragraph()),
                new DocumentItem(new Paragraph())
            };
            var paragraph = new Paragraph();
            var command = new InsertParagraphCommand(documentItems, paragraph, 1);
            command.Execute();
            Assert.AreEqual(paragraph, documentItems[1].Paragraph);
        }

        [TestMethod]
        public void Unexecute_InsertParagraphCommand_WithSettedPosition_ShouldInsertParagraph()
        {
            var previousParagraph = new Paragraph();
            var documentItems = new List<DocumentItem>()
            {
                new DocumentItem(previousParagraph)
            };
            var paragraph = new Paragraph();
            var command = new InsertParagraphCommand(documentItems, paragraph, 0);
            command.Execute();
            Assert.AreEqual(paragraph, documentItems[0].Paragraph);

            command.Unexecute();
            Assert.AreEqual(previousParagraph, documentItems[0].Paragraph);
        }

        [TestMethod]
        public void Unexecute_InsertParagraphCommand_WithEndPosition_ShouldInsertParagraph()
        {
            var previousParagraph = new Paragraph();
            var documentItems = new List<DocumentItem>()
            {
                new DocumentItem(previousParagraph)
            };
            var paragraph = new Paragraph();
            var command = new InsertParagraphCommand(documentItems, paragraph, null);
            command.Execute();
            Assert.AreEqual(paragraph, documentItems[1].Paragraph);

            command.Unexecute();
            Assert.AreEqual(previousParagraph, documentItems[0].Paragraph);
        }
    }
}
