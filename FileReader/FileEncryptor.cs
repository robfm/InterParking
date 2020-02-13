using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace FileReader
{
    public class FileEncryptor : ICryptor
    {
        public string Decrypt(string text, string key)
        {
            string decryptText = string.Join(" ", text.Split(' ').Select(s => new String(s.Reverse().ToArray())));
            return decryptText;
        }
    }
}
