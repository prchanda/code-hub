namespace CodeHub.Graphs
{
    class VertexBase<T>
    {
        public T Data {get;}
        public VertexBase(T data)
        {
            Data = data;
        }
    }
}