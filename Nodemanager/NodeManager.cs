using Opc.Ua;
using Opc.Ua.Server;
using System.Collections.Generic;

public class NodeManager : CustomNodeManager2
{
    private List<BaseInstanceState> nodes;

    public NodeManager(IServerInternal server, ApplicationConfiguration configuration, string[] namespaceUris)
        : base(server, configuration, namespaceUris)
    {
        nodes = new List<BaseInstanceState>();
    }

    protected override void CreateAddressSpace(IDictionary<NodeId, IList<IReference>> externalReferences)
    {
        foreach (var node in nodes)
        {
            AddPredefinedNode(SystemContext, node);
        }
    }

    public void AddNode(BaseInstanceState node)
    {
        nodes.Add(node);
        AddPredefinedNode(SystemContext, node);
    }

    public void RemoveNode(BaseInstanceState node)
    {
        nodes.Remove(node);
        PredefinedNodes.Remove(node.NodeId);
    }

    public void UpdateNode(BaseInstanceState oldNode, BaseInstanceState newNode)
    {
        int index = nodes.IndexOf(oldNode);
        if (index >= 0)
        {
            nodes[index] = newNode;
            PredefinedNodes.Remove(oldNode.NodeId);
            AddPredefinedNode(SystemContext, newNode);
        }
    }
}
