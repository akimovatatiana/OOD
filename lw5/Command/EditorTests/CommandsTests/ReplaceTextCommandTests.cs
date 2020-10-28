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
            var paragraph = new Text()
            {
                Value = "Old text"
            };
            var newText = "New text";
            var command = new ReplaceTextCommand(paragraph, newText);

            command.Execute();
            Assert.AreEqual(newText, paragraph.Value);
        }

        [TestMethod]
        public void Unexecute_ReplaceTextCommand_ShouldReturnPrevTextToParagraph()
        {
            var prevText = "Old text";
            var paragraph = new Text()
            {
                Value = prevText
            };
            var newText = "New text";
            var command = new ReplaceTextCommand(paragraph, newText);

            command.Execute();
            Assert.AreEqual(newText, paragraph.Value);

            command.Unexecute();
            Assert.AreEqual(prevText, paragraph.Value);
        }
    }
}
