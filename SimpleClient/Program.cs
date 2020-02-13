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

                Console.WriteLine("The file is encrypted?: Y/N");
                var resp = Console.ReadKey();
                Console.WriteLine(Environment.NewLine);

                if (resp.Key == ConsoleKey.Y)
                {
                    FileEncryptor fileEnc = new FileEncryptor();
                    result = fileEnc.Decrypt(result, string.Empty);
                }

                Console.WriteLine(result);                
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
