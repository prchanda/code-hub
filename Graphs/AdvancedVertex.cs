namespace CodeHub.Graphs
{
    class AdvancedVertex<T> : VertexBase<T>
    {
        public T Parent {get;set;}
        public int Rank {get;set;}
        public AdvancedVertex(T child, T parent): base(child)
        {
            Parent = parent;
            Rank = 0;
        }
    }   
}