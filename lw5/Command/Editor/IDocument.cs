namespace Editor
{
    public interface IDocument
    {
        string GetTitle();
        void SetTitle(string title);
        IParagraph InsertParagraph(string text, int? position = null);
        int ItemsCount { get; }
        DocumentItem GetItem(int index);
        void DeleteItem(int position);
        bool CanUndo();
        void Undo();
        bool CanRedo();
        void Redo();
        void Save(string path);
    }
}
