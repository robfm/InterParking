using FileReader.Enums;
using FileReader.Permissions;
using FileReader.Resources;
using System;
using System.IO;

namespace FileReader
{
    public class TextProcessor : IFileProcessor
    {
        private string _path;

        public TextProcessor(string path)
        {
            this._path = path;
        }
        public string Read(int roleId)
        {
            PermissionService permit = new PermissionService();

            if (permit.VerifyAccess((UserRoles.Roles)roleId, UserPermissions.Permissions.CanReadTXTFiles))
            {
                string content = "Text File Content";
                return content;
            }
            else
                throw new Exception(Resource.ExceptionRoleTXT);
        }
    }
}
