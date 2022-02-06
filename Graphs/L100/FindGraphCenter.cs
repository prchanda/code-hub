namespace CodeHub.Graphs.L100
{
/*  There is an undirected star graph consisting of n nodes labeled from 1 to n. A star graph is a graph where there is 
    one center node and exactly n - 1 edges that connect the center node with every other node.

    You are given a 2D integer array edges where each edges[i] = [ui, vi] indicates that there is an edge between the nodes ui and vi.
    Return the center of the given star graph.

    Example 1:

                4
                |
                |
                2
              /   \
             /     \
            1       3

    Input: edges = [[1,2],[2,3],[4,2]]
    Output: 2

*/
    class StarGraph
    {
        public int FindCenter(int[,] edges)
        {
            return edges[0,0] == edges[0,1] || edges[0,0] == edges[1,1] ? edges[0,0]: edges[0,1];
        }
    }
}