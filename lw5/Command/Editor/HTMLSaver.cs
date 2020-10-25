using System.Collections.Generic;
using System.IO;

namespace Editor
{
    public class HTMLSaver
    {
        private readonly List<DocumentItem> _documentItems;
        private readonly Dictionary<string, string> _symbols = new Dictionary<string, string>
        {
            { "&", "&amp;" },
            { "<", "&lt;" },
            { ">", "&gt;" },
            { "'", "&apos;" },
            { "\"", "&quot;" }
        };

        public HTMLSaver(List<DocumentItem> documentItems)
        {
            _documentItems = documentItems;
        }

        public void Save(string path, string title)
        {
            using var sw = new StreamWriter(path);
            sw.WriteLine("<!DOCTYPE html>");
            sw.WriteLine("<html>");
            sw.WriteLine("  <head>");
            sw.WriteLine("    <title>" + ConvertHtmlSymbols(title) + "</title>");
            sw.WriteLine("  </head>");
            sw.WriteLine("  <body>");
            sw.Write(CreateBody());
            sw.WriteLine("  </body>");
            sw.WriteLine("</html>");
        }

        private string CreateBody()
        {
            string str = "";
            foreach (var item in _documentItems)
            {
                str += "    <p>" + ConvertHtmlSymbols(item.Paragraph.Text) + "</p>\n";
            }
            return str;
        }

        private string ConvertHtmlSymbols(string str)
        {
            if (str != null)
            {
                foreach (KeyValuePair<string, string> symbol in _symbols)
                {
                    str = str.Replace(symbol.Key, symbol.Value);
                }
            }
            return str;
        }
    }
}
