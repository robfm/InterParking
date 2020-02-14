using System;
using System.Collections.Generic;
using System.Text;

namespace FileReader.Enums
{
    static public class UserRoles
    {
        [Flags]
        public enum Roles
        {
            Admin = 0,
            Guest = 1
        };
    }
}
