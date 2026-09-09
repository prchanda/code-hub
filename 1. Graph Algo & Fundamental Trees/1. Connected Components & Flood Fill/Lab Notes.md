## Why Choose BFS over DFS?

| **Feature**             | **DFS (Depth-First Search)**                 | **BFS (Breadth-First Search)**   |
| ----------------------- | -------------------------------------------- | -------------------------------- |
| **Data Structure**      | Call Stack (Recursion)                       | `Queue` (Iterative)              |
| **Stack Overflow Risk** | **Yes**, on large grids ($1000 \times 1000$) | **No**, uses heap memory safely  |
| **Exploration Style**   | Explores deep down one path first            | Explores layer-by-layer outwards |

---
### When do I naturally choose DFS?

- Connected Components
- Cycle Detection
- Tree Recursion
- Backtracking
- Flood Fill

---

### When do I naturally choose BFS?

- Shortest Path (Unweighted)
- Level Order Traversal
- Minimum Steps
- Nearest Something
- Multi-source Spread

Whenever you hear:

- Minutes
- Distance
- Simultaneously
- Wave
- Infection
- Spread


### How should you decide between DFS and BFS here?

Usually:

**DFS**

- natural for "explore this entire component"
- very simple recursive implementation
- common choice for grid flood-fill problems

**BFS**

- avoids recursive call-stack overflow
- useful when distance/layers matter
- also perfectly valid for components

Therefore your interview statement should be:

> “This is a connected-component problem on an implicit grid graph. DFS or BFS both work. I'll use DFS because we simply need to exhaust each component and don't need level-order information.”

# Recognizing graph problems

### Obvious clues

- Graph
- Nodes
- Edges
- Vertices

### Grid clues

- Matrix
- Grid
- Maze
- Island
- Region
- Flood Fill

### Real-world disguises

- Cities
- Flights
- Roads
- Computers
- Employees
- Friends
- Accounts
- Rooms
- Courses
- Dependencies

All of these are just different ways of describing nodes and edges.

### Directions array

Instead of:

```
Up
Down
Left
Right
```

they say:

```
You may also move diagonally.
```

With explicit calls, you now have:

```
DFS(...Up);
DFS(...Down);
DFS(...Left);
DFS(...Right);

DFS(...TopLeft);
DFS(...TopRight);
DFS(...BottomLeft);
DFS(...BottomRight);
```

With directions:

```
directions =
{
   {-1,0},
   {1,0},
   {0,-1},
   {0,1},
   {-1,-1},
   {-1,1},
   {1,-1},
   {1,1}
};
```

**Component? → DFS/BFS**

**Component property? → DFS/BFS + aggregation**

**Shortest distance? → BFS**

**Multiple sources → Multi-source BFS**

**All sources' contributions? → BFS from each source**

**Border/enclosure? → Border-first traversal**

**Combine components? → Component IDs + metadata**

**Destination is easier to reason from? → Reverse traversal**



200  → Connected Components
695  → Components + Aggregation
200  → Recursive → Iterative DFS
733  → Connected Component + Modification
130  → Border-First
1020 → Border Elimination
1254 → Border Elimination + Components
827  → Component IDs + Metadata
1905 → Component + Validation