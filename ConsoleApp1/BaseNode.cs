using ConsoleReferenceServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleReferenceServer
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
    public enum IdType
    {
        Numeric = 0,
        String = 1,
        Guid = 2,
        Opaque = 3
    };

    public enum NodeClass
    {
        Unspecified = 0,
        Object = 1,
        Variable = 2,
        Method = 4,
        ObjectType = 8,
        VariableType = 16,
        ReferenceType = 32,
        DataType = 64,
        View = 128
    }
    public struct NodeId
    {
        public required ushort NamespaceIndex { get; set; }
        public IdType IdentifierType { get; set; }
        public required object Identifier { get; set; }

   
     }


    public class DisplayName
    {
        public required string Locale { get; set; }
        public required string Text { get; set; }

    }

    public class UserRolePermission
    {
        public NodeId RoleId { get; set; }
        public uint Permissions { get; set; }
    }
  
}
