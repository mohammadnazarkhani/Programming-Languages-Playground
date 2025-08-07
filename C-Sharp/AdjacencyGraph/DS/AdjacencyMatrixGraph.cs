using System;
using System.Runtime.InteropServices.Marshalling;

namespace AdjacencyGraph.DS;

public class AdjacencyMatrixGraph : GraphBase
{
    int[,] Matrix;

    public AdjacencyMatrixGraph(int numVertices, bool directed = false) : base(numVertices, directed)
    {
        Matrix = GetEmptySquareMatrix(numVertices);
    }

    public override void AddEdge(int v1, int v2, int weight = 1)
    {
        if (v1 >= this.numVertices || v2 >= this.numVertices || v1 < 0 || v2 < 0)
            throw new ArgumentOutOfRangeException("Vertices are out of bounds");

        if (weight < 1) throw new ArgumentException("Weight cannot be less than 1");

        this.Matrix[v1, v2] = weight;

        // In an undirected graph all edges are bi-directional
        if (!this.directed) this.Matrix[v2, v1] = weight;
    }

    public override void Display()
    {
        for (int i = 0; i < this.numVertices; i++)
        {
            var vertices = GetAdjacentVertices(i);
            if (vertices.Count() > 0)
                System.Console.WriteLine(string.Join("->", vertices));
        }
    }

    public override IEnumerable<int> GetAdjacentVertices(int v)
    {
        if (v < 0 || v >= this.numVertices) throw new ArgumentOutOfRangeException("Cannot access vertex");

        List<int> adjacentVertices = new List<int>();
        for (int i = 0; i < this.numVertices; i++)
        {
            if (this.Matrix[v, i] > 0)
                adjacentVertices.Add(i);
        }
        return adjacentVertices;
    }

    public override int GetEdgeWeight(int v1, int v2)
    {
        return this.Matrix[v1, v2];
    }

    private int[,] GetEmptySquareMatrix(int numVertices)
    {
        int[,] matrix = new int[numVertices, numVertices];
        for (int row = 0; row < numVertices; row++)
            for (int col = 0; col < numVertices; col++)
                matrix[row, col] = 0;

        return matrix;
    }
}
