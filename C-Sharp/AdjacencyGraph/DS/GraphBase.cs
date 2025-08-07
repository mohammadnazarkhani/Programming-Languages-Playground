using System;
using System.Security.Cryptography.X509Certificates;

namespace AdjacencyGraph.DS;

public abstract class GraphBase
{
    protected readonly int numVertices;
    protected readonly bool directed;

    public GraphBase(int numVertices, bool directed = false)
    {
        this.numVertices = numVertices;
        this.directed = directed;
    }

    public abstract void AddEdge(int v1, int v2, int weight);

    public abstract IEnumerable<int> GetAdjacentVertices(int v);

    public abstract int GetEdgeWeight(int v1, int v2);

    public abstract void Display();

    public int NumVertices { get { return this.numVertices; } }
}
