using System;

namespace GreedyBestFirst;

public class Map
{
    public HashSet<Node> Nodes { get; set; } = new HashSet<Node>();

    public Node GetNodeById(int nodeId) => Nodes.FirstOrDefault(n => n.NodeId == nodeId) ?? new Node { NodeId = -1 };
}
