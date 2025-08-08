using A_Star;

// Main program to test the A* algorithm
public class Program
{
    private static double Heuristic(Node current, Node goal)
        => Math.Abs(current.X - goal.X) + Math.Abs(current.Y - goal.Y);

    private static List<Node>? AStar(Node start, Node goal, Map map)
    {
        var openList = new List<Node> { start };
        var closedList = new HashSet<Node>();

        // Dictionaries to hold g(n), h(n), and parent pointers
        var gScore = new Dictionary<int, double> { [start.NodeId] = 0 };
        var hScore = new Dictionary<int, double> { [start.NodeId] = Heuristic(start, goal) };
        var parentMap = new Dictionary<int, Node>();

        while (openList.Count > 0)
        {
            // Find node in open list with the lowest F score
            var current = openList.OrderBy(node => gScore[node.NodeId] + hScore[node.NodeId]).First();

            if (current.NodeId == goal.NodeId)
                return ReturnReconstructPath(parentMap, current);

            openList.Remove(current);
            closedList.Add(current);

            foreach (var neighborId in current.Neighbors.Keys)
            {
                var neighbor = map.GetNodeById(neighborId);
                if (neighbor.NodeId == -1 || closedList.Contains(neighbor)) continue;

                // Tentative gScore (current gScore + distance to neighbor)
                double tentativeGScore = gScore[current.NodeId] + current.Neighbors[neighborId];

                if (!gScore.ContainsKey(neighbor.NodeId) || tentativeGScore < gScore[neighbor.NodeId])
                {
                    // Update gScore and hScore
                    gScore[neighbor.NodeId] = tentativeGScore;
                    hScore[neighbor.NodeId] = Heuristic(neighbor, goal);

                    // Set the current node as parent of the neighbor
                    parentMap[neighbor.NodeId] = current;

                    if (!openList.Contains(neighbor))
                        openList.Add(neighbor);
                }
            }
        }

        return null; // No path found
    }

    private static List<Node> ReturnReconstructPath(Dictionary<int, Node> parentMap, Node current)
    {
        var path = new List<Node> { current };

        while (parentMap.ContainsKey(current.NodeId))
        {
            current = parentMap[current.NodeId];
            path.Add(current);
        }
        path.Reverse();
        return path;
    }

    public static void Main()
    {
        // Create a sample map
        var map = new Map();

        // Create some nodes representing a simple grid
        var node0 = new Node { NodeId = 0, X = 0, Y = 0 };
        var node1 = new Node { NodeId = 1, X = 1, Y = 0 };
        var node2 = new Node { NodeId = 2, X = 2, Y = 0 };
        var node3 = new Node { NodeId = 3, X = 0, Y = 1 };
        var node4 = new Node { NodeId = 4, X = 1, Y = 1 };
        var node5 = new Node { NodeId = 5, X = 2, Y = 1 };
        var node6 = new Node { NodeId = 6, X = 0, Y = 2 };
        var node7 = new Node { NodeId = 7, X = 1, Y = 2 };
        var node8 = new Node { NodeId = 8, X = 2, Y = 2 };

        // Add nodes to the map
        map.Nodes.Add(node0);
        map.Nodes.Add(node1);
        map.Nodes.Add(node2);
        map.Nodes.Add(node3);
        map.Nodes.Add(node4);
        map.Nodes.Add(node5);
        map.Nodes.Add(node6);
        map.Nodes.Add(node7);
        map.Nodes.Add(node8);

        // Connect nodes (creating a grid with diagonal connections)
        // Each connection has a distance of 1 for simplicity
        ConnectNodes(node0, node1, 1);
        ConnectNodes(node1, node2, 1);
        ConnectNodes(node3, node4, 1);
        ConnectNodes(node4, node5, 1);
        ConnectNodes(node6, node7, 1);
        ConnectNodes(node7, node8, 1);
        ConnectNodes(node0, node3, 1);
        ConnectNodes(node3, node6, 1);
        ConnectNodes(node1, node4, 1);
        ConnectNodes(node4, node7, 1);
        ConnectNodes(node2, node5, 1);
        ConnectNodes(node5, node8, 1);

        // Find path from node0 (0,0) to node8 (2,2)
        var path = AStar(node0, node8, map);

        // Print results
        Console.WriteLine("Testing A* Pathfinding Algorithm");
        Console.WriteLine("--------------------------------");
        Console.WriteLine($"Finding path from (0,0) to (2,2)");
        
        if (path != null)
        {
            Console.WriteLine("Path found!");
            Console.WriteLine("Path nodes:");
            foreach (var node in path)
            {
                Console.WriteLine($"Node {node.NodeId}: ({node.X}, {node.Y})");
            }
        }
        else
        {
            Console.WriteLine("No path found!");
        }
    }

    private static void ConnectNodes(Node node1, Node node2, double distance)
    {
        node1.Neighbors[node2.NodeId] = distance;
        node2.Neighbors[node1.NodeId] = distance;
    }
}