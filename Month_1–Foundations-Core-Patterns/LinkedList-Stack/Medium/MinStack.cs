public class MinStack {
    Stack<long> stack;
    long min;

    public MinStack() {
        stack = new Stack<long>();
    }
    
    public void Push(int val) {
        if(stack.Count==0)
        {
            stack.Push(0    );
            min = val;
        }
        else
        {
            long diff = (long)val - min;
            stack.Push(diff);
            if(diff<0)
                min = val;
        }
    }
    
    public void Pop() {
        if (stack.Count == 0) 
            return;
        
        long diff = stack.Pop();        
        if(diff<0)
        {            
            min = min - diff;
        }
    }
    
    public int Top() {
        long diff = stack.Peek();
        return diff>=0 ? (int)(min + diff) : (int)min;
    }
    
    public int GetMin() {
        return (int)min;
    }
}