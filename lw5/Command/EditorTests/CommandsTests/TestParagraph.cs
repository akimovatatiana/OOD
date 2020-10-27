using Editor;
using System;

namespace EditorTests.CommandsTests
{
    public class TestParagraph : IParagraph
    {
        public string Text => throw new NotImplementedException();

        public void SetText(string text)
        {
            throw new NotImplementedException();
        }
    }
}
