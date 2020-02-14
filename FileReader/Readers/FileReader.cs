using FileReader.Cryptors;
using FileReader.Permissions;
using FileReader.Resources;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileReader.Readers
{
    public class FileRead
    {
        private IFileProcessor ifile;
        private ICryptor iCrypt;

        private Dictionary<string, IFileProcessor> fileTypes;
        private Dictionary<string, ICryptor> cryptoTypes;

        private string _path;
        private bool _isEncrypted;
        private int _roleId;
        public FileRead(string path, bool isEncrypted, int roleId)
        {
            this._path = path;
            this._isEncrypted = isEncrypted;
            this._roleId = roleId;

            fileTypes = new Dictionary<string, IFileProcessor>();
            cryptoTypes = new Dictionary<string, ICryptor>();

            InitTypes();
            InitInterfaces();
        }

        public string ReadFile()
        {
            if (File.Exists(_path))
            {
                PermissionService permit = new PermissionService();
                permit.VerifyRole(_roleId);

                string texto = ifile.Read(_roleId);

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

        private void InitInterfaces()
        {
            string extension = Path.GetExtension(_path);

            if (!fileTypes.ContainsKey(extension))
                throw new Exception(Resource.ExceptionFileNotSupported);
            else
                this.ifile = fileTypes[extension];

            if (_isEncrypted)
            {
                if (!cryptoTypes.ContainsKey(extension))
                    throw new Exception(Resource.ExceptionFileNotSupported);
                else
                    this.iCrypt = cryptoTypes[extension];
            }
        }
    }
}

