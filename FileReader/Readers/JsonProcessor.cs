using FileReader.Enums;
using FileReader.Permissions;
using FileReader.Resources;
using System;
using System.IO;

namespace FileReader
{
    public class JsonProcessor : IFileProcessor
    {
        private string _path;

        public JsonProcessor(string path)
        {
            this._path = path;
        }
        public string Read(int roleId)
        {
            PermissionService permit = new PermissionService();

            if (permit.VerifyAccess((UserRoles.Roles)roleId, UserPermissions.Permissions.CanReadJsonFiles))
            {
                string content = "Json File Content";
                return content;
            }
            else
                throw new Exception(Resource.ExceptionRoleJson);
        }
    }
}
