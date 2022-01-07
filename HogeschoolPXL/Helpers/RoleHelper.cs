using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogeschoolPXL.Helpers
{
    public class RoleHelper
    {
        public const string AdminRole = "ADMIN";
        public const string StudentRole = "STUDENT";
        public const string LectorRole = "LECTOR";
        public static IEnumerable<string> Roles => GetRoles();

        private static List<string> GetRoles()
        {
            List<string> lst = new List<string>();
            lst.Add(StudentRole);
            lst.Add(LectorRole);
            return lst;
        }
    }
}
