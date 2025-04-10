using Opc.Ua;
using Opc.Ua.Server;
using System.Collections.Generic;

public class NodeManagerFactory : INodeManagerFactory
{
    public INodeManager Create(IServerInternal server, ApplicationConfiguration configuration)
    {
        return new NodeManager(server, configuration, new[] { "nodes", "nodes/instance" });
    }
}
