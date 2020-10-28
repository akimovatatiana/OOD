using Editor.Commands;

namespace Editor
{
    public class Paragraph : IParagraph
    {
        private readonly IText _text = new Text();
        private readonly IHistory _history;

        public string Text => _text.Value;

        public Paragraph(IHistory history, string text)
        {
            _history = history;
            _text.Value = text;
        }

        public void SetText(string text)
        {
            _history.AddAndExecuteCommand(new ReplaceTextCommand(_text, text));
        }
    }
}
