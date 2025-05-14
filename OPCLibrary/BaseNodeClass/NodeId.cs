using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPCLibrary.BaseNodeClass
{
    public struct NodeId
    {
        public required ushort NamespaceIndex { get; set; }
        public IdType IdentifierType { get; set; }
        public required object Identifier { get; set; }

        
    }
}
