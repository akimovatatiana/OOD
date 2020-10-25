using System;
using System.Collections.Generic;

namespace Editor.Commands
{
    public class History
    {
        private readonly List<ICommand> _commands = new List<ICommand>();
        private int _nextCommandIndex = 0;

        public bool CanUndo()
        {
            return _nextCommandIndex > 0;
        }

        public bool CanRedo()
        {
            return _nextCommandIndex != _commands.Count;
        }

        public void Undo()
        {
            if (CanUndo())
            {
                _commands[_nextCommandIndex - 1].Unexecute();
                --_nextCommandIndex;
            }
            else
            {
                throw new IndexOutOfRangeException("Cannot undo! There are no commands before this.");
            }
        }

        public void Redo()
        {
            if (CanRedo())
            {
                _commands[_nextCommandIndex].Execute();
                ++_nextCommandIndex;
            }
            else
            {
                throw new IndexOutOfRangeException("Cannot redo! There are no commands after this.");
            }
        }

        public void AddAndExecuteCommand(ICommand command)
        {
            if (_commands.Count >= 10)
            {
                _commands.RemoveAt(0);
                --_nextCommandIndex;
            }

            if (_nextCommandIndex < _commands.Count)
            {
                _commands.RemoveRange(_nextCommandIndex, _commands.Count - _nextCommandIndex);
            }

            _commands.Add(command);
            command.Execute();
            ++_nextCommandIndex;
        }
    }
}
