using System;
using System.Collections.Generic;
using System.Text;

namespace FileReader
{
    public interface IFileProcessor
    {
        void Read(string path);
    }
}
