using Editor;
using Editor.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EditorTests.CommandsTests
{
    [TestClass]
    public class ReplaceTextCommandTests
    {
        [TestMethod]
        public void Execute_ReplaceTextCommand_WithNewText_ShouldReplacePrevTextFromParagraph()
        {
            var paragraph = new Paragraph()
            {
                Text = "Old text"
            };
            var newText = "New text";
            var command = new ReplaceTextCommand(paragraph, newText);

            command.Execute();
            Assert.AreEqual(newText, paragraph.Text);
        }

        [TestMethod]
        public void Unexecute_ReplaceTextCommand_ShouldReturnPrevTextToParagraph()
        {
            var prevText = "Old text";
            var paragraph = new Paragraph()
            {
                Text = prevText
            };
            var newText = "New text";
            var command = new ReplaceTextCommand(paragraph, newText);

            command.Execute();
            Assert.AreEqual(newText, paragraph.Text);

            command.Unexecute();
            Assert.AreEqual(prevText, paragraph.Text);
        }
    }
}
