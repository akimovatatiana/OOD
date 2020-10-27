namespace Editor.Commands
{
    public class ReplaceTextCommand : AbstractCommand
    {
        private string _newValue = "";
        private readonly IText _text;

        public ReplaceTextCommand(IText text, string newValue)
        {
            _text = text;
            _newValue = newValue;
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
            var temp = _text.Text;
            _text.Text = _newValue;
            _newValue = temp;
        }
    }
}
