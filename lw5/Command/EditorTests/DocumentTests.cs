using Editor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace EditorTests
{
    [TestClass]
    public class DocumentTests
    {
        private readonly IDocument _document = new Document();

        [TestMethod]
        public void SetTitle_WithNewTitle_ShouldSetDocumentTitle()
        {
            string title = "Title";
            _document.SetTitle(title);
            Assert.AreEqual(title, _document.Title);
        }

        [TestMethod]
        public void InsertParagraph_WithTextAndPosition_ShouldInsertParagraph()
        {
            string text1 = "First paragraph";
            string text2 = "Second paragraph";
            string text3 = "Third paragraph";
            _document.InsertParagraph(text1, 0);
            _document.InsertParagraph(text2, 1);
            _document.InsertParagraph(text3);

            Assert.AreEqual(3, _document.ItemsCount);
            Assert.AreEqual(text1, _document.GetItem(0).Paragraph.Text);
            Assert.AreEqual(text2, _document.GetItem(1).Paragraph.Text);
            Assert.AreEqual(text3, _document.GetItem(2).Paragraph.Text);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void InsertParagraph_WithInvalidPosition_ShouldThrowException()
        {
            string text1 = "First paragraph";
            string text2 = "Second paragraph";
            _document.InsertParagraph(text1, 0);
            _document.InsertParagraph(text2, 1);

            _document.InsertParagraph("text", -1);
            _document.InsertParagraph("text", 3);
        }

        [TestMethod]
        public void DeleteItem_WithValidPosition_ShouldNotThrowException()
        {
            string text1 = "First paragraph";
            string text2 = "Second paragraph";
            _document.InsertParagraph(text1, 0);
            _document.InsertParagraph(text2, 1);

            _document.DeleteItem(1);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void DeleteItem_WithInvalidPosition_ShouldThrowException()
        {
            string text1 = "First paragraph";
            string text2 = "Second paragraph";
            _document.InsertParagraph(text1, 0);
            _document.InsertParagraph(text2, 1);

            _document.DeleteItem(-1);
            _document.DeleteItem(3);
        }

        [TestMethod]
        public void ReplaceText_WithValidPosition_ShouldTextInParagraph()
        {
            string text1 = "First paragraph";
            string text2 = "Second paragraph";
            _document.InsertParagraph(text1, 0);

            _document.ReplaceText(text2, 0);

            Assert.AreEqual(text2, _document.GetItem(0).Paragraph.Text);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ReplaceText_WithInvalidPosition_ShouldThrowException()
        {
            string text1 = "First paragraph";
            string text2 = "Second paragraph";
            _document.InsertParagraph(text1, 0);
            _document.InsertParagraph(text2, 1);

            _document.ReplaceText(text1, 0);
            _document.ReplaceText(text1, 2);
        }

        [TestMethod]
        public void GetItem_WtihIndex_ShouldReturnItem()
        {
            string text = "First paragraph";
            _document.InsertParagraph(text, 0);

            Assert.AreEqual(text, _document.GetItem(0).Paragraph.Text);
        }

        [TestMethod]
        public void CanRedo_WithEmptyHistory_ShouldReturnFalse()
        {
            Assert.IsFalse(_document.CanRedo());
        }

        [TestMethod]
        public void CanRedo_WithHistory_ShouldReturnTrue()
        {
            _document.InsertParagraph("Paragraph", 0);
            _document.Undo();
            Assert.IsTrue(_document.CanRedo());
        }

        [TestMethod]
        public void CanUndo_WithEmptyHistory_ShouldReturnFalse()
        {
            Assert.IsFalse(_document.CanUndo());
        }

        [TestMethod]
        public void CanUndo_WithHistory_ShouldReturnTrue()
        {
            _document.InsertParagraph("Paragraph", 0);
            Assert.IsTrue(_document.CanUndo());
        }

        [TestMethod]
        public void Redo_WithHistory_ShouldRedoCommand()
        {
            _document.InsertParagraph("Paragraph", 0);
            _document.Undo();
            _document.Redo();
        }

        [TestMethod]
        public void Save_WithTitleAndParagraphs_ShouldSaveDocumentToFile()
        {
            string path = Directory.GetCurrentDirectory() + "\\index.html";
            _document.Title = "Title";
            _document.InsertParagraph("Paragraph", 0);
            _document.Save(path);

            Assert.IsTrue(File.Exists(path));
            File.Delete(path);
        }

        [TestMethod]
        public void Save_Paragraph_WithSpecialSymbols_ShouldSaveDocumentToFile()
        {
            string path = Directory.GetCurrentDirectory() + "\\index.html";
            var text = "< text > ' \" &";
            _document.InsertParagraph(text, 0);
            var expected = "    <p>&lt; text &gt; &apos; &quot; &amp;</p>";
            _document.Save(path);
            Assert.IsTrue(File.Exists(path));

            var hasString = false;
            using (var sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line == expected)
                    {
                        hasString = true;
                        break;
                    }
                }
            }

            Assert.IsTrue(hasString);
            File.Delete(path);
        }
    }
}
