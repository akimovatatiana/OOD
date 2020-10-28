namespace Editor.Commands
{
    public interface IHistory
    {
        void AddAndExecuteCommand(ICommand command);
    }
}
