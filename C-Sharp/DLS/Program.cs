
Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>()
{
    {"A", new List<string> { "B", "C" } },
    { "B", new List<string> { "D" } },
    { "C", new List<string> { "D", "E" } },
    { "D", new List<string> { "F" } },
    { "E", new List<string> { "F" } },
    { "F", new List<string>() },
    { "G", new List<string>() }
};

string startNode = "A";
string goalNode = "F";
int depthLimit = 3;

Console.WriteLine($"Searching for {goalNode} with depth limit {depthLimit}...");

HashSet<string> visited = new HashSet<string>();
bool found = DepthLimitedDFS(graph, startNode, goalNode, depthLimit, visited);

if (found)
    Console.WriteLine($"Goal {goalNode} found within depth limit.");
else
    Console.WriteLine($"Goal {goalNode} NOT found within depth limit.");


static bool DepthLimitedDFS(Dictionary<string, List<string>> graph, string current, string goal, int depthLimit, HashSet<string> visited)
{
    Console.WriteLine($"Visiting: {current}, Remaining depth: {depthLimit}");

    if (current == goal)
        return true;

    if (depthLimit <= 0)
        return false;

    visited.Add(current);

    foreach (var neighbor in graph[current])
    {
        if (!visited.Contains(neighbor))
        {
            if (DepthLimitedDFS(graph, neighbor, goal, depthLimit - 1, visited))
                return true;
        }
    }

    return false;
}