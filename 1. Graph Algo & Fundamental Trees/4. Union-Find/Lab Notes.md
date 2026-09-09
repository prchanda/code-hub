DFS/BFS is for exploring the graph. Union-Find is for maintaining connectivity. So Union-Find doesn't care about the **path**. It only cares about the **component**.

Union-Find doesn't explore paths. It maintains which component each node belongs to.

| If the problem asks...                                          | Prefer               |
| --------------------------------------------------------------- | -------------------- |
| "Can I reach `B` from `A`?"                                     | **DFS/BFS**          |
| "What is the shortest path?"                                    | **BFS** (unweighted) |
| "Visit/explore all nodes"                                       | **DFS/BFS**          |
| "How many connected components?"                                | **DFS/BFS**          |
| "What are the actual nodes/path in a component?"                | **DFS/BFS**          |
| "Are these two nodes already connected?" repeatedly             | **Union-Find**       |
| "Merge these two components" repeatedly                         | **Union-Find**       |
| "Does adding this edge create a cycle?"                         | **Union-Find**       |
| "How many components remain after adding/removing connections?" | **Often Union-Find** |
| Connections arrive dynamically                                  | **Union-Find**       |
When you see a graph problem, ask these two questions:

**1. Do I need to explore/traverse something?**

```
path
neighbors
distance
reachability
visit all nodes
```

→ **DFS/BFS**

**2. Do I mostly need to maintain "who belongs to which group?"**

```
connected?
merge groups
already connected?
cycle from adding an edge?
dynamic connectivity
```

→ **Union-Find**

And there's a particularly useful phrase to recognize:

> **"Given a sequence of edges/connections, determine whether two nodes are already connected."**

My brain immediately goes:

**"Union-Find."**