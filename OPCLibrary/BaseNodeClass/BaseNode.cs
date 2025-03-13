using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OPCLibrary.BaseNodeClass
{

    public class BaseNode
    {
        public required NodeId NodeId { get; set; }
        public required DisplayName DisplayName { get; set; }
        public required string FullPath { get; set; }
        public required NodeId DataType { get; set; }
        public required int ValueRank { get; set; }
        public required byte AccessLevel { get; set; }
        public required List<UserRolePermission> UserRolePermissions { get; set; }


    }
  
}
