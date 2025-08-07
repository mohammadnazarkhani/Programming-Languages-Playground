using AdjacencyGraph.DS;

var adjMatrixGraph = new AdjacencyMatrixGraph(9, false);
adjMatrixGraph.AddEdge(0, 8);
adjMatrixGraph.AddEdge(0, 3);
adjMatrixGraph.AddEdge(8, 4);
var adjacent = adjMatrixGraph.GetAdjacentVertices(8);
adjMatrixGraph.Display();