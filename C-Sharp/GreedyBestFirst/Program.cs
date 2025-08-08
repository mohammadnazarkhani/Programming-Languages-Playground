using GreedyBestFirst;

class Program
{
    static void Main(string[] args)
    {
        // Create a simple map with nodes forming a grid
        Map map = new Map();
        
        // Create nodes in a 3x3 grid
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                map.Nodes.Add(new Node 
                { 
                    NodeId = i * 3 + j,
                    X = j,
                    Y = i
                });
            }
        }

        // Connect nodes (creating edges)
        foreach (var node in map.Nodes)
        {
            // Connect horizontal neighbors
            var rightNeighbor = map.Nodes.FirstOrDefault(n => n.X == node.X + 1 && n.Y == node.Y);
            if (rightNeighbor != null)
            {
                node.Neighbors.Add(rightNeighbor);
                rightNeighbor.Neighbors.Add(node);
            }

            // Connect vertical neighbors
            var bottomNeighbor = map.Nodes.FirstOrDefault(n => n.X == node.X && n.Y == node.Y + 1);
            if (bottomNeighbor != null)
            {
                node.Neighbors.Add(bottomNeighbor);
                bottomNeighbor.Neighbors.Add(node);
            }
        }

        // Create search algorithm instance
        var search = new GreedyBestFIrst(map);

        // Test cases
        TestSearch(search, map, 0, 8, "Start(0,0) to Goal(2,2)");
        TestSearch(search, map, 1, 7, "Start(0,1) to Goal(2,1)");
        TestSearch(search, map, 0, 2, "Start(0,0) to Goal(0,2)");
        TestSearch(search, map, 4, 4, "Same start and goal node");
    }

    static void TestSearch(GreedyBestFIrst search, Map map, int startId, int goalId, string testDescription)
    {
        Console.WriteLine($"\nTest: {testDescription}");
        var start = map.GetNodeById(startId);
        var goal = map.GetNodeById(goalId);
        
        var path = search.Search(start, goal);
        
        if (path == null)
        {
            Console.WriteLine("No path found!");
        }
        else
        {
            Console.WriteLine($"Path found with {path.Count} nodes:");
            foreach (var node in path)
            {
                Console.WriteLine($"Node {node.NodeId} at ({node.X}, {node.Y})");
            }
        }
    }
}