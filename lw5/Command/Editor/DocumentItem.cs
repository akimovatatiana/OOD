using System.Security.Cryptography;

namespace Editor
{
    public class DocumentItem
    {
        public IParagraph Paragraph { get; }

        public DocumentItem(IParagraph paragraph)
        {
            Paragraph = paragraph;
        }
    }
}
