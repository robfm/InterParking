using System;
using System.IO;
using FileReader;

namespace SimpleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter the path of the file: ");
                string path = Console.ReadLine();
                FileRead fread = new FileRead(path);
                string result = fread.ReadFile();
                Console.WriteLine(result);                
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
