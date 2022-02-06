using System.Collections.Generic;
using System.Linq;
using System;

namespace CodeHub.Graphs
{
    class AdjacencyList<T>
    {
        public List<Vertex<T>> Vertices {get;}
        Dictionary<T, int> indexLookup;
        bool isDirected;

        public AdjacencyList(bool isDirected)
        {
            Vertices = new List<Vertex<T>>();
            indexLookup = new Dictionary<T, int>();
            this.isDirected = isDirected;
        }

        public void AddVertex(T data)
        {
            Vertices.Add(new Vertex<T>(data));
            indexLookup.Add(data, Vertices.Count-1);
        }

        public void AddEdge(T source, T destination, int weight=1)
        {
            int sourceIndex = indexLookup[source];
            int destinationIndex = indexLookup[destination];
            Vertices[sourceIndex].Edges.Add(new Edge<T>(Vertices[destinationIndex], weight));
            if(!isDirected)
                Vertices[destinationIndex].Edges.Add(new Edge<T>(Vertices[sourceIndex], weight));                
        }

        public void RemoveEdge(T source, T destination)
        {
            int sourceIndex = indexLookup[source];
            int destinationIndex = indexLookup[destination];
            var destinationEdge = Vertices[sourceIndex].Edges.FirstOrDefault(edge => edge.Neighbour == Vertices[destinationIndex]);
            Vertices[sourceIndex].Edges.Remove(destinationEdge);
            if(!isDirected)
            {
                var sourceEdge = Vertices[destinationIndex].Edges.FirstOrDefault(edge => edge.Neighbour == Vertices[sourceIndex]);
                Vertices[destinationIndex].Edges.Remove(sourceEdge);
            }
        }

        public List<T> GetNeighbours(T vertex)
        {
            int vertexIndex = indexLookup[vertex];
            return Vertices[vertexIndex].Edges.Select(vertex => vertex.Neighbour.Data).ToList();
        }

        public void Display()
        {
            Console.WriteLine("\nVertex: Neighbours are as follows-\n");
            foreach (var vertex in Vertices)
            {
                Console.WriteLine($"{vertex.Data}: {string.Join(", ", GetNeighbours(vertex.Data))}");
            }
        }
    }
}