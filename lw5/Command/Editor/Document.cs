using Editor.Commands;
using System;
using System.Collections.Generic;

namespace Editor
{
    public class Document : IDocument
    {
        private readonly List<DocumentItem> _documentItems = new List<DocumentItem>();
        public string Title { get; set; }
        public int ItemsCount => _documentItems.Count;
        private readonly History _history = new History();

        public void SetTitle(string title)
        {
            _history.AddAndExecuteCommand(new SetTitleCommand(this, title));
        }

        public bool CanRedo()
        {
            return _history.CanRedo();
        }

        public bool CanUndo()
        {
            return _history.CanUndo();
        }

        public void Redo()
        {
            _history.Redo();
        }

        public void Undo()
        {
            _history.Undo();
        }

        public void Save(string path)
        {
            var htmlSaver = new HTMLSaver(_documentItems);
            htmlSaver.Save(path, Title);
        }

        public IParagraph InsertParagraph(string text, int? position = null)
        {
            if (position.HasValue && (position < 0 || position > ItemsCount))
            {
                throw new IndexOutOfRangeException($"Invalid position: {position}. Cannot insert paragraph.");
            }

            var paragraph = new Paragraph { Text = text };
            _history.AddAndExecuteCommand(new InsertParagraphCommand(_documentItems, paragraph, position));
            return paragraph;
        }

        public void DeleteItem(int position)
        {
            if (position < 0 || position > ItemsCount)
            {
                throw new IndexOutOfRangeException($"Invalid position: {position}. Cannot delete item.");
            }

            _history.AddAndExecuteCommand(new DeleteItemCommand(_documentItems, position));
        }

        public DocumentItem GetItem(int index)
        {
            return (index >= ItemsCount || index < 0) ? throw new IndexOutOfRangeException($"There is no item by {index} index.") : _documentItems[index];
        }
    }
}
