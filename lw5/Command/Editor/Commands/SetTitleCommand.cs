namespace Editor.Commands
{
    public class SetTitleCommand : AbstractCommand
    {
        private readonly IDocument _document;
        private string _target;

        public SetTitleCommand(IDocument document, string target)
        {
            _document = document;
            _target = target;
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
            var temp = _document.Title;
            _document.Title = _target;
            _target = temp;
        }
    }
}
