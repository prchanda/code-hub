**1. Unweighted shortest path → BFS**  
Every edge costs the same? → BFS.

**2. Weighted shortest path → Dijkstra**  
Non-negative weights? → Dijkstra + PriorityQueue.

**3. Multiple starting points → Multi-source BFS**  
Multiple sources at time 0? → Put all in queue first.

**4. Connected components → DFS/BFS**  
Explore an entire group? → DFS/BFS.

**5. Dynamic connectivity → Union-Find**  
Repeatedly join groups / ask if connected? → Union-Find.

**6. Dependencies → Topological Sort**  
"A must happen before B"? → Topological Sort.

**7. Tree subtree information → DFS + return value**  
What does the parent need from this subtree? → Return it.

**8. Tree path using both children → Post-order + global answer**  
Return one branch; combine both branches globally.

**9. Tree ancestor constraints → DFS + bounds**  
What restrictions come from ancestors? → Carry bounds downward.

**10. Tree levels / distance from root → BFS**  
Need level-by-level processing? → Queue + `size`.

**11. Limited stops / edges → Bellman-Ford**  
At most K edges/stops? → Layered relaxation.


```
Shortest Path
     │
     ├── Are edges unweighted / same cost?
     │          │
     │          └── YES → BFS
     │
     └── Are edges weighted?
                │
                ├── All weights ≥ 0
                │       │
                │       └── Dijkstra
                │
                └── Negative weights possible
                        │
                        ├── General graph → Bellman-Ford
                        │
                        └── DAG → Topological DP
```


##### A Minimum Spanning Tree connects **all nodes**, uses exactly **N−1 edges**, contains **no cycles**, and has the **minimum possible total edge weight**

`Kruskal's algorithm is a greedy method used to find a MST by selecting the lowest-weight edges one by one without forming cycles. Union-Find is what makes the **"does this create a cycle?"** check efficient.`

Mental model:

`All edges
   ↓
Sort by cost
   ↓
Take cheapest edge
   ↓
Does it create a cycle?
   ↓
NO → take it + Union
YES → skip it
   ↓
N - 1 edges selected`


`Prim's algorithm is a greedy method in computer science that finds a MST for a connected, weighted, and undirected graph`

Mental model:

`Start with one node
       ↓
Find cheapest edge going OUT
       ↓
Add that node
       ↓
   Repeat`

##### Key Differences

1. **Starting Point**: Prim's algorithm starts from a single random vertex and grows outward. Kruskal's algorithm starts with all separate vertices and no connections.
2. **Selection Focus**: Prim's looks at edges connected to the currently visited group of nodes. Kruskal's looks at all edges in the whole graph at the same time.
3. **Action**: Prim's adds the shortest edge touching the visited tree. Kruskal's sorts all edges by weight and adds the smallest one if it does not make a loop.
4. **Data Structure**: Prim's uses a priority queue. Kruskal's uses a union-find data structure.
5. **Graph Type Efficiency**: Prim's works faster on dense graphs with many edges. Kruskal's works faster on sparse graphs with few edges.


