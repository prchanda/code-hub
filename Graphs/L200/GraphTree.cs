using System.Collections.Generic;

namespace CodeHub.Graphs.L200
{
/*  Given n nodes labeled from 0 to n-1 and a list of undirected edges (each edge is a pair of nodes), write a function to 
    check whether these edges make up a valid tree.

    Example 1:
    Input: n = 5, and edges = [[0,1], [0,2], [0,3], [1,4]]
    Output: true

    Example 2:
    Input: n = 5, and edges = [[0,1], [1,2], [2,3], [1,3], [1,4]]
    Output: false

    Solution Explaination:

    A graph is a valid tree if it satifies these two conditions:
    1. If its acyclic.
    2. If its connected.

    We can use DFS/BFS to detect cycle in graph, following that we can if all of the vertices are being visited as part of DFS/BFS traversal.
    If any of the vertices is not in the visited list, then its a disconnected graph.
*/

    class GraphTree<T>
    {
        List<Vertex<int>> vertices;
        Dictionary<int, int> indexLookup;
        
        public GraphTree()
        {
            vertices = new List<Vertex<int>>();
            indexLookup = new Dictionary<int, int>();
        }
        
        private void AddVertex(int data)
        {
            vertices.Add(new Vertex<int>(data));
            indexLookup.Add(data, vertices.Count-1);
        }
        
        private void AddEdge(int source, int destination)
        {
            var sourceVertex = vertices[indexLookup[source]];
            var destinationVertex = vertices[indexLookup[destination]];
            sourceVertex.Edges.Add(new Edge<int>(destinationVertex));
            destinationVertex.Edges.Add(new Edge<int>(sourceVertex));
        }
        
        private bool IsCyclic(Vertex<int> vertex, HashSet<Vertex<int>> visited, Vertex<int> parent)
        {
            visited.Add(vertex);
            var edges = vertex.Edges;
            foreach(var edge in edges)
            {
                if (!visited.Contains(edge.Neighbour))
                {
                    if (IsCyclic(edge.Neighbour, visited, vertex))
                        return true;
                }
                else if (edge.Neighbour != parent)
                    return true;
            }
            return false;
        }
        
        private bool IsConnected(HashSet<Vertex<int>> visited)
        {
            bool result = true;
            foreach(var vertex in vertices)
            {
                if(!visited.Contains(vertex))
                {
                    result = false;
                    break;
                }
            }
            return result;
        }
    
        public bool IsValidTree(int n, int[,] edges)
        {
            for (int vertex = 0; vertex < n; vertex++)
            {
                AddVertex(vertex);
            }
            for (int row = 0; row < edges.GetLength(0); row++)
            {
                AddEdge(edges[row,0], edges[row,1]);
            }
            HashSet<Vertex<int>> visited = new HashSet<Vertex<int>>();
            bool result = IsCyclic(vertices[0], visited, null);
            if(result)
                return false;
            else
                result = IsConnected(visited);
            return result;
        }
    }
}