using System;

namespace DFS;

public class DFS
{
    public void DFSRecursive(int start, HashSet<int> visited)
    {
        if (visited.Contains(start))
        {
            return;
        }

        visited.Add(start);
        Console.WriteLine(start);

        foreach(var neighbor in GetNeighbors(start))
        {
            DFSRecursive(neighbor, visited);
        }
    }

    public void DFSIterative(int start)
    {
        var visited = new HashSet<int>();
        var stack = new Stack<int>();
        stack.Push(start);

        while (stack.Count > 0)
        {
            var current = stack.Pop();
            if (visited.Contains(current))
            {
                continue;
            }

            visited.Add(current);
            Console.WriteLine(current);

            foreach (var neighbor in GetNeighbors(current))
            {
                if (!visited.Contains(neighbor))
                {
                    stack.Push(neighbor);
                }
            }
        }
    }

    private IEnumerable<int> GetNeighbors(int start)
    {
        return start switch
        {
            1 => new List<int> { 2, 3 },
            2 => new List<int> { 4, 5 },
            3 => new List<int> { 6 },
            4 => new List<int> { },
            5 => new List<int> { },
            6 => new List<int> { },
            _ => throw new ArgumentException("Invalid node")
        };
    }
}
