using BFS;

Graph graph = new Graph();

// Add some edges to the graph
graph.AddEdge(1, 2);
graph.AddEdge(1, 3);
graph.AddEdge(1, 4);
graph.AddEdge(2, 5);
graph.AddEdge(3, 6);
graph.AddEdge(3, 7);

List<int> visited = graph.BreadthFirstSearch(1);

foreach (var node in visited)
    Console.Write(node + " ");