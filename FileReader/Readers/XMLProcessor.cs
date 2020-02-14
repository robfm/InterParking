using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using FileReader.Permissions;
using FileReader.Enums;
using FileReader.Resources;

namespace FileReader
{
    public class XMLProcessor : IFileProcessor
    {
        public string _path;
        public XMLProcessor(string path)
        {
            this._path = path;
        }

        public string Read(int roleId)
        {
            PermissionService permit = new PermissionService();

            if (permit.VerifyAccess((UserRoles.Roles)roleId, UserPermissions.Permissions.CanReadXMLFiles))
            {
                string content = "XML File Content";
                return content;
            }
            else
                throw new Exception(Resource.ExceptionRoleXML);
        }
    }
}
