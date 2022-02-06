using System.Collections.Generic;

namespace CodeHub.Graphs
{
    class Vertex<T> : VertexBase<T>
    {
        public List<Edge<T>> Edges {get;set;}
        public Vertex(T data): base(data)
        {
            Edges = new List<Edge<T>>();
        }
    }   
}