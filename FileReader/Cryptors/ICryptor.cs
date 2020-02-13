using System;
using System.Collections.Generic;
using System.Text;

namespace FileReader.Cryptors
{
    interface ICryptor
    {
        string Decrypt(string text);
    }
}
