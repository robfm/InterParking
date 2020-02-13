using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileReader.Cryptors
{
    class TextCryptor : ICryptor
    {
        public string Decrypt(string text)
        {
            string decryptText = string.Join(" ", text.Split(' ').Select(s => new String(s.Reverse().ToArray())));
            return decryptText;
        }
    }
}
