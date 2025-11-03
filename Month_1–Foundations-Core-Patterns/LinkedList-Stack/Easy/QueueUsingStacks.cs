public class MyQueue {
    private Stack<int> stackIn;
    private Stack<int> stackOut;

    public MyQueue() {
        stackIn = new Stack<int>();
        stackOut = new Stack<int>();
    }
    
    // Push element x to the back of queue.
    public void Push(int x) {
        stackIn.Push(x);
    }
    
    // Removes the element from in front of queue and returns that element.
    public int Pop() {
        MoveIfNeeded();
        return stackOut.Pop();
    }
    
    // Get the front element.
    public int Peek() {
        MoveIfNeeded();
        return stackOut.Peek();
    }
    
    // Returns whether the queue is empty.
    public bool Empty() {
        return stackIn.Count == 0 && stackOut.Count == 0;
    }

    // Helper function to move elements from stackIn to stackOut if stackOut is empty
    private void MoveIfNeeded() {
        if (stackOut.Count == 0) {
            while (stackIn.Count > 0) {
                stackOut.Push(stackIn.Pop());
            }
        }
    }
}