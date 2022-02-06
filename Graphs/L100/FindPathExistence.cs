using System.Collections.Generic;

namespace CodeHub.Graphs.L100
{
/*  Given an undirected graph with N vertices and E edges and two vertices (U, V) from the graph, the task is to detect 
    if a path exists between these two vertices. Print “Yes” if a path exists and “No” otherwise.

    Example 1:
    
    1       2

        3

    Input: U = 1, V = 2 
    Output: No 

    Example 2:

    1 ------ 2
    |        |
    |        |
    |        |
    4------- 3

    Input: U = 1, V = 3 
    Output: Yes
*/
    class PathFinder<T>
    {       
        HashSet<T> isVisited;

        public PathFinder()
        {
            isVisited = new HashSet<T>();
        }  

        public string CheckIfPathExists(AdjacencyList<T> graph, T source, T destination)
        {
            bool result = DFS(graph, source, destination);
            if(!result)
            {
                for (int index = 0; index < graph.Vertices.Count; index++)
                {
                    var vertex = graph.Vertices[index].Data;
                    if(!isVisited.Contains(vertex) && DFS(graph, vertex, destination))                        
                        break;
                }
            }
            return result ? "Yes" : "No";
        }

        private bool DFS(AdjacencyList<T> graph, T source, T destination)
        {            
            isVisited.Add(source);            
            List<T> neighbours = graph.GetNeighbours(source);
            bool foundDestination = false;
            foreach (var neighbour in neighbours)
            {
                if(!isVisited.Contains(neighbour))
                {
                    if(neighbour.Equals(destination))
                    {
                        foundDestination = true;
                        break;
                    }
                    else
                        foundDestination = DFS(graph, neighbour, destination);
                }
            }
            return foundDestination;
        }
    }
}