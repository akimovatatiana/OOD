using System.Collections.Generic;

namespace Editor.Commands
{
    public class DeleteItemCommand : AbstractCommand
    {
        private readonly List<DocumentItem> _documentItems;
        private readonly DocumentItem _documentItem;
        private readonly int _position;

        public DeleteItemCommand(List<DocumentItem> documentItems, int position)
        {
            _documentItems = documentItems;
            _documentItem = documentItems[position];
            _position = position;
        }

        protected override void DoExecute()
        {
            _documentItems.RemoveAt(_position);
        }

        protected override void DoUnexecute()
        {
            _documentItems.Insert(_position, _documentItem);
        }
    }
}
