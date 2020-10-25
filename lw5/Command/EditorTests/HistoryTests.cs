using Editor;
using Editor.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace EditorTests
{
    [TestClass]
    public class HistoryTests
    {
        [TestMethod]
        public void CanUndo_WithIndexGreaterThanZero_ShouldReturnTrue()
        {
            var history = new History();
            var document = new Document();
            var command = new SetTitleCommand(document, "title");
            history.AddAndExecuteCommand(command);
            Assert.IsTrue(history.CanUndo());
        }

        [TestMethod]
        public void CanUndo_WithIndexLessThanZero_ShouldReturnFalse()
        {
            var history = new History();
            Assert.IsFalse(history.CanUndo());
        }

        [TestMethod]
        public void CanRedo_WithValidIndex_ShouldReturnTrue()
        {
            var history = new History();
            var document = new Document();
            var command = new SetTitleCommand(document, "title");
            history.AddAndExecuteCommand(command);
            history.Undo();
            Assert.IsTrue(history.CanRedo());
        }

        [TestMethod]
        public void CanRedo_WithInvalidIndex_ShouldReturnFalse()
        {
            var history = new History();
            Assert.IsFalse(history.CanRedo());
        }

        [TestMethod]
        public void Undo_WithIndexGreaterThanZero_ShouldUndoCommand()
        {
            var history = new History();
            var document = new Document();
            var command = new SetTitleCommand(document, "title");
            history.AddAndExecuteCommand(command);
            Assert.IsTrue(history.CanUndo());
            history.Undo();
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Undo_WithIndexLessThanZero_ShouldThrowException()
        {
            var history = new History();
            history.Undo();
        }

        [TestMethod]
        public void Redo_WithValidIndex_ShouldRedoCommand()
        {
            var history = new History();
            var document = new Document();
            var command = new SetTitleCommand(document, "title");
            history.AddAndExecuteCommand(command);
            history.Undo();
            Assert.IsTrue(history.CanRedo());
            history.Redo();
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Redo_WithInvalidIndex_ShouldThrowException()
        {
            var history = new History();
            history.Redo();
        }

        [TestMethod]
        public void AddAndExecuteCommand_WithElevenCommands_ShouldRemoveFirstCommand()
        {
            var history = new History();
            var document = new Document();
            var command = new SetTitleCommand(document, "title");
            history.AddAndExecuteCommand(command);
            history.AddAndExecuteCommand(command);
            history.AddAndExecuteCommand(command);
            history.AddAndExecuteCommand(command);
            history.AddAndExecuteCommand(command);
            history.AddAndExecuteCommand(command);
            history.AddAndExecuteCommand(command);
            history.AddAndExecuteCommand(command);
            history.AddAndExecuteCommand(command);
            history.AddAndExecuteCommand(command);
            history.AddAndExecuteCommand(command);
        }

        [TestMethod]
        public void AddAndExecuteCommand_With_ShouldRemoveFirstCommand()
        {
            var history = new History();
            var document = new Document();
            var items = new List<DocumentItem>();
            var paragraph = new Paragraph()
            {
                Text = "text"
            };
            var command1 = new SetTitleCommand(document, "title");
            var command2 = new InsertParagraphCommand(items, paragraph, 0);
            var command3 = new InsertParagraphCommand(items, paragraph, 1);
            var command4 = new InsertParagraphCommand(items, paragraph, 1);
            history.AddAndExecuteCommand(command1);
            history.AddAndExecuteCommand(command2);
            history.AddAndExecuteCommand(command3);
            history.AddAndExecuteCommand(command4);
            history.Undo();
            history.Undo();
            history.Undo();
            history.AddAndExecuteCommand(command2);
            history.AddAndExecuteCommand(command3);
        }
    }
}
