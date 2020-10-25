namespace Editor
{
    public interface IDocument
    {
        string Title { get; set; }
        void SetTitle(string title);
        IParagraph InsertParagraph(string text, int? position = null);
        int ItemsCount { get; }
        DocumentItem GetItem(int index);
        void DeleteItem(int position);
        void ReplaceText(string text, int position);
        bool CanUndo();
        void Undo();
        bool CanRedo();
        void Redo();
        void Save(string path);
    }
}
