using System;
using System.IO;

namespace FileReader
{
    public class TextProcessor : IFileProcessor
    {
        public void Read(string path)
        {
            if (File.Exists(path))
            {
                Console.WriteLine("Text File Read");
            }
            else
                Console.WriteLine("This file doesn't exist.");
        }
    }
}
