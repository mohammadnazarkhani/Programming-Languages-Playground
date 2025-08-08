using System;

namespace A_Star;

public class Node
{
    public int NodeId { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public Dictionary<int, double> Neighbors { get; set; } = new Dictionary<int, double>(); // key: neighbor id, value: distance
}
