using System;

namespace GreedyBestFirst;

public class Node
{
    public int NodeId { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public List<Node> Neighbors { get; set; } = new List<Node>();
}
