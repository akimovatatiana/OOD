using System;

namespace MultiGumballMachine
{
    public class Item
    {
        public string Shortcut { get; }
        public string Description { get; }
        public Action<string[]> Command { get; }

        public Item(string shortcut, string description, Action<string[]> command)
        {
            Shortcut = shortcut;
            Description = description;
            Command = command;
        }
    }
}
