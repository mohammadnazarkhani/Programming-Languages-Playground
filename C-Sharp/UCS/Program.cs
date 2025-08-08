using UCS;

class Program
{
    static void Main(string[] args)
    {
        // Example usage of UniformCostSearch
        GFG.graph.Add(new List<int> { 1, 2 });
        GFG.graph.Add(new List<int> { 0, 3 });
        GFG.graph.Add(new List<int> { 0, 3 });
        GFG.graph.Add(new List<int> { 1 });

        // Add bidirectional edge costs
        GFG.edgeCost[(0, 1)] = GFG.edgeCost[(1, 0)] = 1;
        GFG.edgeCost[(0, 2)] = GFG.edgeCost[(2, 0)] = 4;
        GFG.edgeCost[(1, 3)] = GFG.edgeCost[(3, 1)] = 2;
        GFG.edgeCost[(2, 3)] = GFG.edgeCost[(3, 2)] = 1;

        var goalStates = new List<int> { 3 };
        int startNode = 0;

        var result = GFG.UniformCostSearch(goalStates, startNode);
        
        if (result.Count > 0)
        {
            Console.WriteLine($"Reached goal state {result[0]} with cost {result[1]}");
        }
        else
        {
            Console.WriteLine("No goal state reachable.");
        }
    }
}