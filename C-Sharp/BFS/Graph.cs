using System;

namespace BFS;

public class Graph
{
    Dictionary<int, List<int>> edges = new Dictionary<int, List<int>>();

    public void AddEdge(int u, int v)
    {
        if (!edges.ContainsKey(u))
            edges.Add(u, new List<int>());
        if (!edges.ContainsKey(v))
            edges.Add(v, new List<int>());

        edges[u].Add(v);
    }

    public List<int> BreadthFirstSearch(int start)
    {
        List<int> visited = new List<int>();

        Queue<int> queue = new Queue<int>();

        queue.Enqueue(start);

        while (queue.Count > 0)
        {
            int node = queue.Dequeue();

            if (!visited.Contains(node))
            {
                visited.Add(node);

                foreach (var neighbor in edges[node])
                    queue.Enqueue(neighbor);
            }
        }

        return visited;
    }
}
