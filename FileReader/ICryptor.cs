using System;
using System.Collections.Generic;
using System.Text;

namespace FileReader
{
    interface ICryptor
    {
        string Decrypt(string text, string key);
    }
}
