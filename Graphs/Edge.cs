namespace CodeHub.Graphs
{
    class Edge<T>
    {
        public Vertex<T> Neighbour {get;}
        public int Weight {get;}

        public Edge(Vertex<T> neighbour, int weight)
        {
            Neighbour = neighbour;
            Weight = weight;
        }
    }
}