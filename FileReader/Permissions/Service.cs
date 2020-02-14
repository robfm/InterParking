using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using FileReader.Enums;
using FileReader.Resources;

namespace FileReader.Permissions
{
    public class PermissionService
    {
        private Dictionary<UserRoles.Roles, List<UserPermissions.Permissions>> currentPermissions;

        public PermissionService()
        {
            currentPermissions = new Dictionary<UserRoles.Roles, List<UserPermissions.Permissions>>();

            List<UserPermissions.Permissions> adminPermissions = new List<UserPermissions.Permissions>() { UserPermissions.Permissions.All};
            currentPermissions.Add(UserRoles.Roles.Admin, adminPermissions);

            List<UserPermissions.Permissions> guestPermissions = new List<UserPermissions.Permissions>() { UserPermissions.Permissions.CanReadXMLFiles, UserPermissions.Permissions.CanReadTXTFiles };
            currentPermissions.Add(UserRoles.Roles.Guest, guestPermissions);
        }

        public void VerifyRole(int roleId)
        {
            if (!Enum.IsDefined(typeof(UserRoles.Roles), roleId))
                throw new Exception(Resource.ExceptionRoleNotFound);
        }

        public bool VerifyAccess(UserRoles.Roles role, UserPermissions.Permissions permit)
        {
            return currentPermissions[role].Any(a => (a == UserPermissions.Permissions.All || a == permit));                
        }
    }
}
