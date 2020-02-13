using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileReader
{
    public class FileRead
    {
        private readonly IFileProcessor ifile;
        private string _path;
        private Dictionary<string, IFileProcessor> fTypes;
        public FileRead(string path)
        {
            this._path = path;

            fTypes = InitTypes(path);
            string extension = Path.GetExtension(path);

            if (!fTypes.ContainsKey(extension))
                throw new Exception("This file is not supported.");
            else
                this.ifile = fTypes[extension];
        }

        public string ReadFile()
        {
            if (File.Exists(_path))            
               return ifile.Read();
            else
                throw new FileNotFoundException();
        }

        private Dictionary<string, IFileProcessor> InitTypes(string path)
        {
            Dictionary<string, IFileProcessor> fTypes = new Dictionary<string, IFileProcessor>();
            fTypes.Add(".txt", new TextProcessor(path));
            fTypes.Add(".xml", new XMLProcessor(path));

            return fTypes;
        }
    }
}
