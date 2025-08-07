using System;

namespace AdjacencyGraph.DS;

public class Node
{
    private readonly int VertexId;
    private readonly HashSet<int> AdjacencySet;

    public Node(int vertexId)
    {
        this.VertexId = vertexId;
        this.AdjacencySet = new HashSet<int>();
    }

    public void AddEdge(int v)
    {
        if (this.VertexId == v)
            throw new ArgumentException("The vertex cannot be adjacent to itself");
        this.AdjacencySet.Add(v);
    }

    public HashSet<int> GetAdjacentVertices()
    {
        return this.AdjacencySet;
    }
}
