Topological Sort = ordering the vertices of a directed acyclic graph (DAG) so that for every edge `A → B`, `A` appears before `B`.

## The Kahn's Algorithm pattern

This is the pattern I want you to memorize conceptually:

```
Calculate indegree
       ↓
Put all indegree-0 nodes into queue
       ↓
Take node from queue
       ↓
Add it to result
       ↓
"Remove" its outgoing edges
       ↓
Decrease neighbors' indegree
       ↓
If neighbor becomes 0
       ↓
Put neighbor into queue
```

And here's the beautiful part:

### What happens if there's a cycle?

Suppose:

```
A → B
B → C
C → A
```

Indegrees:

```
A = 1
B = 1
C = 1
```

There is **no node with indegree 0**. Therefore:

```
Queue = empty
```

We can't start. That's how Kahn's algorithm detects a cycle.