using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Editor
{
    public class Menu
    {
        private readonly List<Item> _items;
        private bool _exit = false;
        private readonly TextWriter _textWriter;
        private readonly TextReader _textReader;

        public Menu(TextWriter textWriter, TextReader textReader)
        {
            _textWriter = textWriter;
            _textReader = textReader;
            _items = new List<Item>();
        }

        public void AddItem(string shortcut, string description, Action<string[]> command)
        {
            _items.Add(new Item(shortcut, description, command));
        }

        public void Run()
        {
            //ShowInstructions();
            while (!_exit)
            {
                string command = _textReader.ReadLine();
                if (command == null)
                {
                    break;
                }
                try
                {
                    ExecuteCommand(command);
                }
                catch (Exception e)
                {
                    _textWriter.WriteLine(e.Message);
                }
            }
        }

        public void ShowInstructions()
        {
            _textWriter.WriteLine("Commands list:");
            foreach (var command in _items)
            {
                _textWriter.WriteLine($" {command.Shortcut}: {command.Description}");
            }
        }

        public void Exit()
        {
            _exit = true;
        }

        private void ExecuteCommand(string command)
        {
            string[] commandArrData = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            
            if (commandArrData.Count() == 0)
            {
                _textWriter.WriteLine("Unknown command");
                return;
            }

            var item = _items.Where(i => i.Shortcut.ToLower() == commandArrData[0].ToLower());

            if (item.Count() != 0)
            {
                item.First().Command(commandArrData);
            }
            else
            {
                _textWriter.WriteLine($"Unknown command");
            }
        }
    
    }
}
