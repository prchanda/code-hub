using System.Collections.Generic;

namespace CodeHub.Graphs.L300
{
/*  A tree is an undirected graph in which any two vertices are connected by exactly one path. In other words, any connected graph
    without simple cycles is a tree. Given a tree of n nodes labelled from 0 to n - 1, and an array of n - 1 edges where edges[i] = [ai, bi]
    indicates that there is an undirected edge between the two nodes ai and bi in the tree, you can choose any node of the tree as the root.
    When you select a node x as the root, the result tree has height h. Among all possible rooted trees, those with minimum height (i.e. min(h))
    are called minimum height trees (MHTs).

    Return a list of all MHTs' root labels. You can return the answer in any order. The height of a rooted tree is the number of edges on the
    longest downward path between the root and a leaf.

    Input: n = 4, edges = [[1,0],[1,2],[1,3]]
    Output: [1]

    Input: n = 6, edges = [[3,0],[3,1],[3,2],[3,4],[5,4]]
    Output: [3,4]


    Solution Explaination:

    https://www.youtube.com/watch?v=ivl6BHJVcB0
*/
    
    public class MinimumHeightTrees
    {
        public IList<int> FindRoots(int n, int[,] edges)
        {            
            if(n<=2)
            {
                IList<int> mhtRoots = new List<int>();
                for(int index=0; index<n; index++)
                    mhtRoots.Add(index);
                return mhtRoots;
            }
            IList<List<int>> graph = new List<List<int>>();
            for(int index=0; index<n; index++)
                graph.Add(new List<int>());

            for (int row = 0; row < edges.GetLength(0); row++)
            {
                graph[edges[row,0]].Add(edges[row,1]);
                graph[edges[row,1]].Add(edges[row,0]);
            }

            IList<int> leaves = new List<int>();
            for (int index = 0; index < graph.Count; index++)
            {
                if(graph[index].Count == 1)
                    leaves.Add(index);
            }

            while (n > 2)
            {
                n-=leaves.Count;
                IList<int> newLeaves = new List<int>();
                foreach (var leaf in leaves)
                {
                    var neighbour = graph[leaf][0];
                    graph[neighbour].Remove(leaf);
                    if(graph[neighbour].Count == 1)
                        newLeaves.Add(neighbour);                       
                }
                leaves = newLeaves;
            }

            return leaves;
        }
    }
}