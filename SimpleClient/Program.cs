using System;
using FileReader.Readers;
using FileReader.Cryptors;

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

                Console.WriteLine("Is the file encrypted?: Y/N");
                var resp = Console.ReadKey();
                Console.WriteLine(Environment.NewLine);

                bool isEncrypted = resp.Key == ConsoleKey.Y;

                FileRead fread = new FileRead(path, isEncrypted);
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
