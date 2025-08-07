using System;

namespace AdjacencyGraph.DS;

public class AdjacencySetGraph : GraphBase
{
    private HashSet<Node> vertexSet;

    public AdjacencySetGraph(int numVertices, bool directed = false) : base(numVertices, directed)
    {
        this.vertexSet = new HashSet<Node>();
        for (var i = 0; i < numVertices; i++)
            vertexSet.Add(new Node(i));
    }

    public override void AddEdge(int v1, int v2, int weight)
    {
        if (v1 >= this.numVertices || v2 >= this.numVertices || v1 < 0 || v2 < 0)
            throw new ArgumentOutOfRangeException("Vertices are out of bounds");

        if (weight != 1) throw new ArgumentException("An adjacency set cannot represent non-one edge weights");

        this.vertexSet.ElementAt(v1).AddEdge(v2);

        // In an undirected graph all edges are bi-directional
        if (!this.directed) this.vertexSet.ElementAt(v2).AddEdge(v1);
    }

    public override void Display()
    {
        foreach (var node in vertexSet)
        {
            var vertices = node.GetAdjacentVertices();
            if (vertices.Count > 0)
                System.Console.WriteLine(String.Join("->", vertices));
        }
    }

    public override IEnumerable<int> GetAdjacentVertices(int v)
    {
        if (v < 0 || v >= this.numVertices) throw new ArgumentOutOfRangeException("Cannot access vertex");
        return this.vertexSet.ElementAt(v).GetAdjacentVertices();
    }

    public override int GetEdgeWeight(int v1, int v2)
    {
        return 1;
    }
}
