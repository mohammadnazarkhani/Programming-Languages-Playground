// The Data
const airports = "PHX BKK OKC JFK LAX MEX EZE HEL LOS LAP LIM".split(" ");

const routes = [
  ["PHX", "LAX"],
  ["PHX", "JFK"],
  ["JFK", "OKC"],
  ["JFK", "LOS"],
  ["MEX", "LAX"],
  ["MEX", "BKK"],
  ["MEX", "LIM"],
  ["MEX", "EZE"],
  ["LIM", "BKK"],
];

// The graph
const adjanceyList = new Map();

// Add node
function addNode(airport) {
  adjanceyList.set(airport, []);
}

// Add edge, undirected
function addEdge(origin, destination) {
  adjanceyList.get(origin).push(destination);
  adjanceyList.get(destination).push(origin);
}

// Create the Graph
airports.forEach(addNode);
routes.forEach((route) => addEdge(...route));

console.log(adjanceyList);

console.log("\n=====BFS=====\n");

// BFS Breadth First Search
function bfs(start) {
  const visited = new Set();
  const queue = [start];
  visited.add(start);

  while (queue.length > 0) {
    const airport = queue.shift(); // mutates the queue

    const destinations = adjanceyList.get(airport);

    for (const destination of destinations) {
      if (destination === "BKK") console.log(`Found BKK from ${airport}!`);

      if (!visited.has(destination)) {
        visited.add(destination);
        queue.push(destination);
        console.log(destination);
      }
    }
  }
}

bfs("PHX");

console.log("\n=====DFS=====\n");

// DFS Depth First Search
function dfs(start, visited = new Set(), steps = 0) {
  console.log(start);
  visited.add(start);

  const destinations = adjanceyList.get(start);

  for (const destination of destinations) {
    if (destination === "BKK") {
      console.log(`DFS found Bangkok in ${steps + 1} steps`);
      return;
    }

    if (!visited.has(destination)) dfs(destination, visited, steps + 1);
  }
}

dfs("PHX");
