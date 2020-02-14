using System;
using System.Collections.Generic;
using System.Text;

namespace FileReader.Enums
{
    static public class UserPermissions
    {
        [Flags]
        public enum Permissions
        {
            All = 0,
            CanReadXMLFiles = 1,
            CanReadTXTFiles = 2
        }
    }
}
