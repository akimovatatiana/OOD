using Editor;
using Editor.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EditorTests
{
    [TestClass]
    public class ParagraphTests
    {
        [TestMethod]
        public void CanCreateParagraph()
        {
            var text = "text";
            var history = new History();
            var paragraph = new Paragraph(history, text);
            Assert.AreEqual(text, paragraph.Text);
        }

        [TestMethod]
        public void SetText_WithNewValue_ShouldChangeParagraphText()
        {
            string text = "text1";
            string newValue = "text2";
            var history = new History();
            var paragraph = new Paragraph(history, text);
            paragraph.SetText(newValue);
            Assert.AreEqual(newValue, paragraph.Text);
        }
    }
}
