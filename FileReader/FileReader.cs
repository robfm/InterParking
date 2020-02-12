using System;
using System.Collections.Generic;
using System.Text;

namespace FileReader
{
    public class FileRead
    {
        private readonly IFileProcessor ifile;

        public FileRead(IFileProcessor ifile)
        {
            this.ifile = ifile;
        }

        public void ReadFile(string path)
        {
            ifile.Read(path);
        }
    }
}
