using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPCLibrary.BaseNodeClass
{
    public class UserRolePermission
    {
        public NodeId RoleId { get; set; }
        public uint Permissions { get; set; }
    }
}
