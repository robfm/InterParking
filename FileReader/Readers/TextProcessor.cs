using System;
using System.IO;

namespace FileReader
{
    public class TextProcessor : IFileProcessor
    {
        private string _path;

        public TextProcessor(string path)
        {
            this._path = path;
        }
        public string Read(int roleId)
        {
                string content = "Text File Content";
                return content;
        }
    }
}
