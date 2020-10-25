using Editor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace EditorTests
{
    [TestClass]
    public class MenuTests
    {
        [TestMethod]
        public void Run_WithUnknownCommand_ShouldPrintMessage()
        {
            var commandShortcut = "unknownCommand";
            var sr = new StringReader(commandShortcut);
            var sw = new StringWriter();
            var menu = new Menu(sw, sr);

            menu.AddItem("test", "test description", (string[] s) => sw.Write("execute command"));
            menu.Run();

            var expected = "Unknown command\r\n";
            Assert.AreEqual(expected, sw.ToString());
        }

        [TestMethod]
        public void Run_WithEmptyCommand_ShouldPrintMessage()
        {
            string commandShortcut = "\n";
            var sr = new StringReader(commandShortcut);
            var sw = new StringWriter();
            var menu = new Menu(sw, sr);

            menu.Run();

            var expected = "Unknown command\r\n";
            Assert.AreEqual(expected, sw.ToString());
        }
    }
}
