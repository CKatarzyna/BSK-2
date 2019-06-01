using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BSK_2
{
    static class Roles
    {
        public const string Administrator = "ADMIN";
        public const string Moderator = "MODERATOR";
        public const string Guest = "GUEST";

        static public bool CheckPermissionRights()
        {
            return Thread.CurrentPrincipal.IsInRole("ADMIN") || Thread.CurrentPrincipal.IsInRole("MODERATOR");
        }
    }
}
