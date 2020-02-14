using System;
using FileReader.Readers;
using FileReader.Cryptors;
using FileReader.Enums;
using FileReader.Permissions;

namespace SimpleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter the path of the file: ");
                string path = Console.ReadLine();
                Console.WriteLine(Environment.NewLine);

                Console.WriteLine("Is the file encrypted?: Y/N");
                var resp = Console.ReadKey();
                Console.WriteLine(Environment.NewLine);

                bool isEncrypted = resp.Key == ConsoleKey.Y;

                Console.WriteLine("Enter your user role?: " + Environment.NewLine + getRoleList());
                var role = Console.ReadKey().KeyChar.ToString();
                Console.WriteLine(Environment.NewLine);
                int roleId = 0;
                if (!int.TryParse(role, out roleId))
                    throw new Exception("The character entered is not a number.");

                FileRead fread = new FileRead(path, isEncrypted, roleId);
                string result = fread.ReadFile();

                Console.WriteLine(result);                
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static private string getRoleList()
        {
            var rolesIds = Enum.GetValues(typeof(UserRoles.Roles));

            string rolesList = string.Empty;

            foreach (int value in rolesIds)
            {
                rolesList += Enum.GetName(typeof(UserRoles.Roles), value) + " = " + value + " ";
            }

            return rolesList;
        }
    }
}
