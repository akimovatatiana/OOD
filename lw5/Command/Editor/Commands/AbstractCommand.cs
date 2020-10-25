namespace Editor.Commands
{
    public abstract class AbstractCommand : ICommand
    {
        private bool _executed = false;

        public void Execute()
        {
            if (!_executed)
            {
                DoExecute();
                _executed = true;
            }
        }

        public void Unexecute()
        {
            if (_executed)
            {
                DoUnexecute();
                _executed = false;
            }
        }

        protected abstract void DoExecute();
        protected abstract void DoUnexecute();
    }
}
