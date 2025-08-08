using System;
using System.Transactions;

namespace GreedyBestFirst;

public class GreedyBestFIrst(Map parentMap)
{
    public Map ParentMap { get; } = parentMap;

    public List<Node>? Search(Node start, Node goal)
    {
        if (goal == null || start == null) throw new ArgumentNullException("Given nodes can't be null.");

        var visited = new HashSet<Node>();
        var path = new List<Node>();
        var frontier = new PriorityQueue<Node, int>();
        var cameFrom = new Dictionary<Node, Node>();

        frontier.Enqueue(start, start.GetHuristic(goal));
        visited.Add(start);
        
        while (frontier.Count > 0)
        {
            var current = frontier.Dequeue();
            
            if (current == goal)
            {
                // Reconstruct path
                var node = current;
                while (node != null)
                {
                    path.Insert(0, node);
                    cameFrom.TryGetValue(node, out node);
                }
                return path;
            }

            foreach (var neighbor in current.Neighbors)
            {
                if (!visited.Contains(neighbor))
                {
                    visited.Add(neighbor);
                    cameFrom[neighbor] = current;
                    frontier.Enqueue(neighbor, neighbor.GetHuristic(goal));
                }
            }
        }

        return null;
    }
}
