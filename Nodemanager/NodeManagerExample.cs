using Opc.Ua;
using Opc.Ua.Server;

public class NodeManagerExample
{
    public static void InitializeNodeManager(IServerInternal server, ApplicationConfiguration configuration)
    {
        var nodeManager = new NodeManager(server, configuration);
        server.NodeManager.AddNodeManager(nodeManager);
    }
}
