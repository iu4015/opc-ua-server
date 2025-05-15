using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Opc.Ua;
using Opc.Ua.Client;

namespace OPCLibrary.BaseNodeClass
{
    public class NodeValue
    {

        public NodeId NodeId { get; set; }

        public object? Value { get; set; }

        public StatusCode StatusCode { get; set; }

        public DateTime SourceTimestamp { get; set; }
        
    }
}
