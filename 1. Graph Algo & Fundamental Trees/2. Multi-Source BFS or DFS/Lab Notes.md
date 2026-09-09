417 → Reverse Traversal 
994 → Multi-Source BFS + Time
542 → Multi-Source BFS + Distance
317 → Repeated BFS + Aggregation

**Destination is easier to reason from? → Reverse traversal**

The deeper idea isn't really "`size` calculates the queue size." It's:

> **`size` freezes the current BFS frontier so newly discovered nodes belong to the next distance level.**

When you hear:

- **Shortest path**
- **Minimum number of steps**
- **Minutes**
- **Time taken**
- **Level**
- **Distance**
- **Exactly K steps**
- **Spread in waves**

```cs
while (queue.Count > 0)
{
    int size = queue.Count;
    for (int i = 0; i < size; i++)
    {
        ...
    }
    distance++;
}
```

### So your golden rule is:

> **Need the nearest/best result → first BFS arrival is enough → process each cell once.** (Example - LC 542 - 01 Matrix)

versus:

> **Need to aggregate results from multiple sources → run BFS per source and accumulate.** (Example - LC 317 - Shortest Distance from All Buildings)