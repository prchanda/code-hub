namespace CodeHub.Graphs
{
    class Edge<T>
    {
        public Vertex<T> Neighbour {get;}
        public int Weight {get;}

        public Edge(Vertex<T> neighbour, int weight=1)
        {
            Neighbour = neighbour;
            Weight = weight;
        }
    }
}