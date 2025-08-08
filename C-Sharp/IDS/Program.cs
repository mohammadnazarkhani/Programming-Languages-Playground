Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>
{
    { "A", new List<string> { "B", "C" } },
    { "B", new List<string> { "D", "E" } },
    { "C", new List<string> { "F" } },
    { "D", new List<string> { } },
    { "E", new List<string> { "F" } },
    { "F", new List<string> { } }
};

string start = "A";
string goal = "F";
int maxDepth = 5;

System.Console.WriteLine(
    IterativeDeepeningSearch(graph, start, goal, maxDepth)
        ? "Goal found!"
        : "Goal not found."
);

static bool IterativeDeepeningSearch(Dictionary<string, List<string>> graph, string start, string goal, int maxDepth = 5)
{
    int depth = 0;
    while (true)
    {
        bool found = DepthLimitedSearch(graph, start, goal, depth);
        if (found)
        {
            return true;
        }
        depth++;
        if (depth > maxDepth)
            return false;
    }
}

static bool DepthLimitedSearch(Dictionary<string, List<string>> graph, string start, string goal, int depth)
{
    if (depth == 0 && start == goal)
    {
        return true;
    }
    if (depth > 0)
    {
        if (graph.ContainsKey(start))
        {
            foreach (var neighbor in graph[start])
            {
                if (DepthLimitedSearch(graph, neighbor, goal, depth - 1))
                {
                    return true;
                }
            }
        }
    }
    return false;
}