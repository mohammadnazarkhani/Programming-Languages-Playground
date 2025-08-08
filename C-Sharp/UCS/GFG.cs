using System;

namespace UCS;

public class GFG
{
    public static List<List<int>> graph = new List<List<int>>();

    // Map to store cost of edges
    public static Dictionary<(int, int), int> edgeCost = new Dictionary<(int, int), int>();

    // Returns the minimum cost in a vectore (if there are multiple goal states)
    public static List<int> UniformCostSearch(List<int> goal, int start)
    {
        // Priority queue to store the states to be explored
        var pq = new SortedSet<(int cost, int node)>();
        pq.Add((0, start));

        // Map to store the minimum cost to reach each node
        var minCost = new Dictionary<int, int>();
        minCost[start] = 0;

        while (pq.Count > 0)
        {
            var (currentCost, currentNode) = pq.Min;
            pq.Remove(pq.Min);

            // If we reached a goal state, return the cost
            if (goal.Contains(currentNode))
            {
                return new List<int> { currentNode, currentCost };
            }

            // Explore neighbors
            foreach (var neighbor in graph[currentNode])
            {
                int cost = edgeCost[(currentNode, neighbor)];
                int newCost = currentCost + cost;

                if (!minCost.ContainsKey(neighbor) || newCost < minCost[neighbor])
                {
                    minCost[neighbor] = newCost;
                    pq.Add((newCost, neighbor));
                }
            }
        }

        return new List<int>(); // Return empty if no goal is reachable
    }
}
