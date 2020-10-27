using Editor.Commands;

namespace Editor
{
    public class Paragraph : IParagraph, IText
    {
        public string Text { get; set; }
        private readonly History _history;

        public Paragraph(History history, string text)
        {
            _history = history;
            Text = text;
        }

        public void SetText(string text)
        {
            _history.AddAndExecuteCommand(new ReplaceTextCommand(this, text));
        }
    }
}
