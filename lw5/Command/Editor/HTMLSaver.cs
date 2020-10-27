using System;
using System.Collections.Generic;
using System.IO;

namespace Editor
{
    public class HTMLSaver
    {
        private readonly List<DocumentItem> _documentItems;
        private readonly List<Tuple<string, string>> _symbols = new List<Tuple<string, string>>
        {
            new Tuple<string, string>("&", "&amp;"),
            new Tuple<string, string>("<", "&lt;"),
            new Tuple<string, string>(">", "&gt;"),
            new Tuple<string, string>("'", "&apos;"),
            new Tuple<string, string>("\"", "&quot;")
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
                foreach (var symbol in _symbols)
                {
                    str = str.Replace(symbol.Item1, symbol.Item2);
                }
            }
            return str;
        }
    }
}
