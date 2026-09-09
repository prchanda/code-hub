
## Problem Statement

You are given two nodes `p` and `q` in a binary tree.

Each node has:

```
class Node
{
    public int val;
    public Node left;
    public Node right;
    public Node parent;
}
```

Find the **lowest common ancestor (LCA)** of `p` and `q`.

The **lowest common ancestor** is the lowest node in the tree that has both `p` and `q` as descendants.

You can assume:

- All node values are unique.
- `p` and `q` exist in the tree.
- The tree has parent pointers.
- `p` is not the same as `q`.

### Example 1

```
          3
        /   \
       5     1
      / \   / \
     6   2 0   8
        / \
       7   4

p = 5
q = 1
```

Answer:

```
3
```

Because `3` is the first common ancestor of `5` and `1`.

### Example 2

```
          3
        /   \
       5     1
      / \
     6   2
        / \
       7   4

p = 5
q = 4
```

Answer:

```
5
```


```cs
public class Solution
{
    public Node LowestCommonAncestor(Node p, Node q)
    {
        Node a = p;
        Node b = q;

        while (a != b)
        {
            a = a == null ? q : a.parent;
            b = b == null ? p : b.parent;
        }

        return a;
    }
}
```


### Why does this work?

Suppose:

```
        3
       / \
      5   1
     / \
    6   2
       / \
      7   4

p = 6
q = 4
```

Their paths toward the root are:

```
p: 6 → 5 → 3
q: 4 → 2 → 5 → 3
```

The problem is that the paths have **different lengths**.

So we use the same trick as **intersection of two linked lists**.

```
a: p → ... → root → null → q → ... → root
b: q → ... → root → null → p → ... → root
```

After switching paths, both pointers have traversed the **same total distance**.

Eventually:

```
a == b
```

at the LCA.