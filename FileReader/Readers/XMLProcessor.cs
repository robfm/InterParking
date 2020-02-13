using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileReader
{
    public class XMLProcessor : IFileProcessor
    {
        public string _path;
        public XMLProcessor(string path)
        {
            this._path = path;
        }

        public string Read()
        {
                string content = "XML File Content";
                return content;
        }
    }
}
