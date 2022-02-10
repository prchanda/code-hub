using System.Collections.Generic;

namespace CodeHub.Graphs.L200
{
/*  Given a reference of a node in a connected undirected graph. Return a deep copy (clone) of the graph.
    Each node in the graph contains a value (int) and a list (List[Node]) of its neighbors.

    Solution Explaination:

    https://www.youtube.com/watch?v=mQeF6bN8hMk
*/

    class Cloner<T>
    {
        Dictionary<Vertex<T>, Vertex<T>> cloneLookup;
        
        public Vertex<T> CloneGraph(Vertex<T> node) {
            cloneLookup = new Dictionary<Vertex<T>, Vertex<T>>();
            return Clone(node);
        }
        
        private Vertex<T> Clone(Vertex<T> node)
        {
            if(node == null)
                return null;
            if(cloneLookup.ContainsKey(node))
                return cloneLookup[node];
            
            Vertex<T> nodeClone = new Vertex<T>(node.Data);
            cloneLookup.Add(node, nodeClone);
            foreach(var edge in node.Edges)
            {
                nodeClone.Edges.Add(new Edge<T>(Clone(edge.Neighbour)));
            }
            return nodeClone;
        }
    }
}