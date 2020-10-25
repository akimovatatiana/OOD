namespace Editor.Commands
{
    public class ReplaceTextCommand : AbstractCommand
    {
        private readonly IParagraph _paragraph;
        private string _text;

        public ReplaceTextCommand(IParagraph paragraph, string text)
        {
            _paragraph = paragraph;
            _text = text;
        }

        protected override void DoExecute()
        {
            Swap();
        }

        protected override void DoUnexecute()
        {
            Swap();
        }

        private void Swap()
        {
            var temp = _paragraph.Text;
            _paragraph.Text = _text;
            _text = temp;
        }
    }
}
