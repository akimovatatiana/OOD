using System.IO;
using System.Linq;

namespace Editor
{
    public class Editor
    {
        private readonly Menu _menu;
        private readonly IDocument _document;
        private readonly TextReader _textReader;
        private readonly TextWriter _textWriter;

        public Editor(TextWriter textWriter, TextReader textReader)
        {
            _textReader = textReader;
            _textWriter = textWriter;
            _menu = new Menu(_textWriter, _textReader);
            _document = new Document();
            _menu.AddItem("insertParagraph", "Insert paragraph <position>|end <text>", InsertParagraph);
            _menu.AddItem("setTitle", "Set title of document <title>", SetTitle);
            _menu.AddItem("list", "Show document as list", ShowList);
            _menu.AddItem("replace", "Replace text in paragraph <position>|end <text>", ReplaceText);
            _menu.AddItem("delete", "Delete item <position>", DeleteItem);
            _menu.AddItem("help", "Show help", ShowInstructions);
            _menu.AddItem("exit", "Exit programm", Exit);
            _menu.AddItem("undo", "Undo command", Undo);
            _menu.AddItem("redo", "Redo command", Redo);
            _menu.AddItem("save", "Save document to html <path>", Save);
        }

        public void Start()
        {
            _menu.Run();
        }

        private void DeleteItem(string[] args)
        {
            if (args.Length < 2)
            {
                _textWriter.WriteLine("Not enough arguments! Usage: delete <position>");
            }
            else
            {
                int position = int.Parse(args[1]);
                _document.DeleteItem(position);
            }
        }

        private void InsertParagraph(string[] args)
        {
            if (args.Length < 3)
            {
                _textWriter.WriteLine("Not enough arguments! Usage: insertParagraph <position>|end <text>");
            }
            else
            {
                int? position = args[1].ToLower() != "end" ? int.Parse(args[1]) : (int?)null;
                var text = string.Join(" ", args.Skip(2));
                _document.InsertParagraph(text, position);
            }
        }

        private void ReplaceText(string[] args)
        {
            if (args.Length < 3)
            {
                _textWriter.WriteLine("Not enough arguments! Usage: replace <position>|end <text>");
            }
            else
            {
                int position = int.Parse(args[1]);
                var text = string.Join(" ", args.Skip(2));
                _document.ReplaceText(text, position);
            }
        }

        private void Save(string[] args)
        {
            if (args.Length < 2)
            {
                _textWriter.WriteLine("Not enough arguments! Usage: save <path>");
            }
            else
            {
                var path = args[1];
                _document.Save(path);
            }
        }

        private void Redo(string[] args)
        {
            _document.Redo();
        }

        private void Undo(string[] args)
        {
            _document.Undo();
        }

        private void Exit(string[] args)
        {
            _menu.Exit();
        }

        private void ShowInstructions(string[] args)
        {
            _menu.ShowInstructions();
        }

        private void ShowList(string[] args)
        {
            _textWriter.WriteLine($"Title: {_document.Title}");
            for (var i = 0; i < _document.ItemsCount; i++)
            {
                var item = _document.GetItem(i);
                if (item.Paragraph != null)
                {
                    _textWriter.WriteLine($"{i}. Paragraph: {item.Paragraph.Text}");
                }
            }
        }

        private void SetTitle(string[] args)
        {
            if (args.Length < 2)
            {
                _textWriter.WriteLine("Not enough arguments! Usage: setTitle <title>");
            }
            else
            {
                var str = string.Join(" ", args.Skip(1).ToArray());
                _document.SetTitle(str);
            }
        }      
    }
}
