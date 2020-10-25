using Editor;
using Editor.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EditorTests.CommandsTests
{
    [TestClass]
    public class SetTitleCommandTests
    {
        [TestMethod]
        public void Execute_SetTitleCommand_WithNewTitle_ShouldRenameTitle()
        {
            var document = new Document
            {
                Title = "Prev title"
            };

            string newTitle = "New Title";

            var command = new SetTitleCommand(document, newTitle);

            command.Execute();
            Assert.AreEqual(newTitle, document.Title);
        }

        [TestMethod]
        public void Unexecute_SetTitleCommand_WithCurrentTitle_ShouldRenameTitle()
        {
            var document = new Document();
            var previousTitle = "Prev Title";
            document.Title = previousTitle;

            string newTitle = "New Title";

            var command = new SetTitleCommand(document, newTitle);

            command.Execute();
            Assert.AreEqual(newTitle, document.Title);

            command.Unexecute();
            Assert.AreEqual(previousTitle, document.Title);
        }
    }
}
