using Opc.Ua;
using Opc.Ua.Server;
using System.Collections.Generic;

public class NodeManager : CustomNodeManager2
{
    private List<BaseInstanceState> nodes;

    public NodeManager(IServerInternal server, ApplicationConfiguration configuration)
        : base(server, configuration)
    {
        nodes = new List<BaseInstanceState>();
    }

    protected override void CreateAddressSpace(IDictionary<NodeId, IList<IReference>> externalReferences)
    {
    }

    public void AddNode(BaseInstanceState node)
    {
        nodes.Add(node);
    }

    public void RemoveNode(BaseInstanceState node)
    {
        nodes.Remove(node);
    }

    public void UpdateNode(BaseInstanceState oldNode, BaseInstanceState newNode)
    {
        int index = nodes.IndexOf(oldNode);
        if (index >= 0)
        {
            nodes[index] = newNode;
        }
    }
}
