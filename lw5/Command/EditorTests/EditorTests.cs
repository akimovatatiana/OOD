using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace EditorTests
{
	[TestClass]
    public class EditorTests
    {
		[TestMethod]
		public void InsertParagraph_WithCorrectArgs_ShouldInsertParagraphToDocument()
		{
			var command = "insertParagraph 0 text1\ninsertParagraph end text2\n";
			var sr = new StringReader(command);
			var sw = new StringWriter();
			Editor.Editor editor = new Editor.Editor(sw, sr);
			editor.Start();
			var expected = "";
			Assert.AreEqual(expected, sw.ToString());
		}

		[TestMethod]
		public void InsertParagraph_WithInvalidArgsCount_ShouldPrintMessage()
		{
			var command = "insertParagraph\ninsertParagraph 1\n";
			var sr = new StringReader(command);
			var sw = new StringWriter();
			Editor.Editor editor = new Editor.Editor(sw, sr);
			editor.Start();
			var expected = "Not enough arguments! Usage: insertParagraph <position>|end <text>\r\n" +
				"Not enough arguments! Usage: insertParagraph <position>|end <text>\r\n";
			Assert.AreEqual(expected, sw.ToString());
		}

		[TestMethod]
		public void ReplaceText_WithCorrectArgs_ShouldReplaceTextInParagraph()
		{
			var command = "insertParagraph 0 text1\nreplace 0 text2\n";
			var sr = new StringReader(command);
			var sw = new StringWriter();
			Editor.Editor editor = new Editor.Editor(sw, sr);
			editor.Start();
			var expected = "";
			Assert.AreEqual(expected, sw.ToString());
		}

		[TestMethod]
		public void ReplaceText_WithInvalidArgsCount_ShouldPrintMessage()
		{
			var command = "insertParagraph 0 text1\nreplace 0\nreplace\n";
			var sr = new StringReader(command);
			var sw = new StringWriter();
			Editor.Editor editor = new Editor.Editor(sw, sr);
			editor.Start();
			var expected = "Not enough arguments! Usage: replace <position>|end <text>\r\n" +
				"Not enough arguments! Usage: replace <position>|end <text>\r\n";
			Assert.AreEqual(expected, sw.ToString());
		}

		[TestMethod]
		public void ReplaceText_WithInvalidPosition_ShouldPrintMessage()
		{
			var command = "insertParagraph 0 text\nreplace 1 text2\n";
			var sr = new StringReader(command);
			var sw = new StringWriter();
			Editor.Editor editor = new Editor.Editor(sw, sr);
			editor.Start();
			var expected = "There is no item by 1 index.\r\n";
			Assert.AreEqual(expected, sw.ToString());
		}

		[TestMethod]
		public void DeleteItem_WithInvalidArgsCount_ShouldPrintMessage()
		{
			var command = "delete\n";
			var sr = new StringReader(command);
			var sw = new StringWriter();
			Editor.Editor editor = new Editor.Editor(sw, sr);
			editor.Start();
			var expected = "Not enough arguments! Usage: delete <position>\r\n";
			Assert.AreEqual(expected, sw.ToString());
		}

		[TestMethod]
		public void DeleteItem_WithCorrectArgs_ShouldDeleteItemFromDocument()
		{
			var command = "insertParagraph 0 text\ndelete 0\n";
			var sr = new StringReader(command);
			var sw = new StringWriter();
			Editor.Editor editor = new Editor.Editor(sw, sr);
			editor.Start();
			var expected = "";
			Assert.AreEqual(expected, sw.ToString());
		}

		[TestMethod]
		public void SetTitle_WithCorrectArgs_ShouldSetTitleToDocument()
		{
			var command = "setTitle title\n";
			var sr = new StringReader(command);
			var sw = new StringWriter();
			Editor.Editor editor = new Editor.Editor(sw, sr);
			editor.Start();
			var expected = "";
			Assert.AreEqual(expected, sw.ToString());
		}

		[TestMethod]
		public void SetTitle_WithInvalidArgsCount_ShouldPrintMessage()
		{
			var command = "setTitle\n";
			var sr = new StringReader(command);
			var sw = new StringWriter();
			Editor.Editor editor = new Editor.Editor(sw, sr);
			editor.Start();
			var expected = "Not enough arguments! Usage: setTitle <title>\r\n";
			Assert.AreEqual(expected, sw.ToString());
		}

		[TestMethod]
		public void ShowList_ShouldPrintAllDocumentElements()
		{
			var command = "setTitle title\ninsertParagraph 0 first\ninsertParagraph end last\nlist";
			var sr = new StringReader(command);
			var sw = new StringWriter();
			Editor.Editor editor = new Editor.Editor(sw, sr);
			editor.Start();
			var expected = "Title: title\r\n0. Paragraph: first\r\n1. Paragraph: last\r\n";
			Assert.AreEqual(expected, sw.ToString());
		}

		[TestMethod]
		public void Exit_ShouldStopProgrammRunning()
		{
			var command = "setTitle title\nlist\nexit";
			var sr = new StringReader(command);
			var sw = new StringWriter();
			Editor.Editor editor = new Editor.Editor(sw, sr);
			editor.Start();
			var expected = "Title: title\r\n";
			Assert.AreEqual(expected, sw.ToString());
		}

		[TestMethod]
		public void Undo_ShouldUndoCommand()
		{
			var command = "setTitle title\nundo\nlist";
			var sr = new StringReader(command);
			var sw = new StringWriter();
			Editor.Editor editor = new Editor.Editor(sw, sr);
			editor.Start();
			var expected = "Title: \r\n";
			Assert.AreEqual(expected, sw.ToString());
		}

		[TestMethod]
		public void Redo_ShouldRedoUndoCommand()
		{
			var command = "setTitle title\nundo\nredo\nlist";
			var sr = new StringReader(command);
			var sw = new StringWriter();
			Editor.Editor editor = new Editor.Editor(sw, sr);
			editor.Start();
			var expected = "Title: title\r\n";
			Assert.AreEqual(expected, sw.ToString());
		}

		[TestMethod]
		public void Save_WithCorrectArgs_ShouldSaveSocumentToPath()
		{
			string path = Directory.GetCurrentDirectory() + "\\index.html";
			var command = $"save {path}";
			var sr = new StringReader(command);
			var sw = new StringWriter();
			Editor.Editor editor = new Editor.Editor(sw, sr);
			editor.Start();
			var expected = "";

			Assert.AreEqual(expected, sw.ToString());
			Assert.IsTrue(File.Exists(path));
			File.Delete(path);
		}

		[TestMethod]
		public void Save_WithInvalidArgsCount_ShouldPrintMessage()
		{
			var command = "save";
			var sr = new StringReader(command);
			var sw = new StringWriter();
			Editor.Editor editor = new Editor.Editor(sw, sr);
			editor.Start();

			var expected = "Not enough arguments! Usage: save <path>\r\n";
			Assert.AreEqual(expected, sw.ToString());
		}

		[TestMethod]
		public void ShowInstructions_ShouldShowHelpInfo()
		{
			var command = "help\n";
			var sr = new StringReader(command);
			var sw = new StringWriter();
			Editor.Editor editor = new Editor.Editor(sw, sr);
			editor.Start();
			var expected = "Commands list:\r\n" +
				" insertParagraph: Insert paragraph <position>|end <text>\r\n" +
				" setTitle: Set title of document <title>\r\n" +
				" list: Show document as list\r\n" +
				" replace: Replace text in paragraph <position>|end <text>\r\n" +
				" delete: Delete item <position>\r\n" +
				" help: Show help\r\n" +
				" exit: Exit programm\r\n" +
				" undo: Undo command\r\n" +
				" redo: Redo command\r\n" +
				" save: Save document to html <path>\r\n";
			Assert.AreEqual(expected, sw.ToString());
		}
	}
}
