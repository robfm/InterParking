using FileReader.Cryptors;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileReader.Readers
{
    public class FileRead
    {
        private readonly IFileProcessor ifile;
        private readonly ICryptor iCrypt;

        private Dictionary<string, IFileProcessor> fileTypes;
        private Dictionary<string, ICryptor> cryptoTypes;

        private string _path;
        private bool _isEncrypted;
        public FileRead(string path, bool isEncrypted)
        {
            this._path = path;
            this._isEncrypted = isEncrypted;

            fileTypes = new Dictionary<string, IFileProcessor>();
            cryptoTypes = new Dictionary<string, ICryptor>();

            InitTypes();
            string extension = Path.GetExtension(_path);

            if (!fileTypes.ContainsKey(extension))
                throw new Exception("This file is not supported.");
            else
                this.ifile = fileTypes[extension];

            if (isEncrypted)
            {
                if (!cryptoTypes.ContainsKey(extension))
                    throw new Exception("This file is not supported.");
                else
                    this.iCrypt = cryptoTypes[extension];
            }
        }

        public string ReadFile()
        {
            if (File.Exists(_path))
            {
                string texto = ifile.Read();

                if (_isEncrypted)
                    texto = iCrypt.Decrypt(texto);

                return texto;
            }
            else
                throw new FileNotFoundException();
        }

        private void InitTypes()
        {
            fileTypes.Add(".txt", new TextProcessor(_path));
            fileTypes.Add(".xml", new XMLProcessor(_path));

            cryptoTypes.Add(".txt", new TextCryptor());
        }
    }
}

