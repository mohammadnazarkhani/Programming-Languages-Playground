using System;

namespace A_Star;

public class Map
{
    public HashSet<Node> Nodes { get; set; } = new HashSet<Node>();

    /// <summary>
    /// Retrieve a node by its id
    /// </summary>
    public Node GetNodeById(int nodeId) => Nodes.FirstOrDefault(n => n.NodeId == nodeId) ?? new Node { NodeId = -1 };
}
