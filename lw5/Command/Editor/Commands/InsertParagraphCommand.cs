using System.Collections.Generic;

namespace Editor.Commands
{
    public class InsertParagraphCommand : AbstractCommand
    {
        private readonly List<DocumentItem> _documentItems;
        private readonly IParagraph _paragraph;
        private readonly int? _position;

        public InsertParagraphCommand(List<DocumentItem> documentItems, IParagraph paragraph, int? position)
        {
            _documentItems = documentItems;
            _paragraph = paragraph;
            _position = position;
        }

        protected override void DoExecute()
        {
            if (!_position.HasValue)
            {
                _documentItems.Add(new DocumentItem(_paragraph));
            }
            else
            {
                _documentItems.Insert((int)_position, new DocumentItem(_paragraph));
            }
        }

        protected override void DoUnexecute()
        {
            if (!_position.HasValue)
            {
                _documentItems.RemoveAt(_documentItems.Count - 1);
            }
            else
            {
                _documentItems.RemoveAt((int)_position);
            }
        }
    }
}
