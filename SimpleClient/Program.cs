using System;
using FileReader;

namespace SimpleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            IFileProcessor txt = new TextProcessor();
            FileRead fread = new FileRead(txt);

            Console.WriteLine("Enter the path of the file to be read: ");
            string path = Console.ReadLine();

            fread.ReadFile(path);
        }
    }
}
