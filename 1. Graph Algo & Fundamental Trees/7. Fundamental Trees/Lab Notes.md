In computer science, **depth** of a node is the number of edges from the root to that node (starting at 0 for the root). **Height** of a node is the number of edges on the longest path from that node down to a leaf (ending at 0 for a leaf). The height of an entire tree equals the height of its root node.

The **depth** of a node is the number of edges from the **root** to that node.

For the tree:

      1   
    /  \  
    2  3  
	/  
    4

Show more lines

- Depth of node 1 = 0 (root)
- Depth of node 2 = 1
- Depth of node 3 = 1
- **Depth of node 4 = 2**

Path from root to node 4:

1 → 2 → 4

There are **2 edges**, so the **depth of node 4 is 2**. ✅

### Height of a Node

- Height = number of edges on the **longest path from that node down to a leaf**.
- Defined for **every node**.

### Height of a Tree

- Height of a tree = height of the **root node**.

### Easy way to remember

- **Depth**: measure **upward** to the root.
- **Height**: measure **downward** to the deepest leaf.
- 
**Tree comparison DFS:** Compare two nodes using base cases for null structure and a value check, then recursively require both corresponding subtrees to match. The key pattern is **"same value + same left subtree + same right subtree."**


| Problem            | Pattern you should remember                  |
| ------------------ | -------------------------------------------- |
| Find Leaves        | Postorder DFS + height                       |
| Duplicate Subtrees | Postorder + subtree serialization            |
| Distribute Coins   | Postorder + subtree balance                  |
| Construct Tree     | Recursion + preorder/inorder ranges          |
| Diameter           | Postorder + height + global answer           |
| Maximum Path Sum   | Postorder + one-sided return + global answer |
| Validate BST       | DFS + bounds / inorder                       |
| LCA                | DFS / BST ordering                           |
| Level Order        | BFS                                          |
| Right Side View    | BFS/DFS + level                              |
| Serialize Tree     | DFS/BFS representation                       |
| House Robber III   | Tree DP + take/skip                          |