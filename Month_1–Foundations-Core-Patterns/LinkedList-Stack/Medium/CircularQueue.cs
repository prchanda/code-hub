public class MyCircularQueue {
    private int[] queue;
    private int front;
    private int rear;
    private int count;
    private int capacity;

    public MyCircularQueue(int k) {
        queue = new int[k];
        capacity = k;
        front = 0;
        rear = -1;
        count = 0;
    }
    
    public bool EnQueue(int value) {
        if (IsFull()) return false;
        rear = (rear + 1) % capacity;
        queue[rear] = value;
        count++;
        return true;
    }
    
    public bool DeQueue() {
        if (IsEmpty()) return false;
        front = (front + 1) % capacity;
        count--;
        return true;
    }
    
    public int Front() {
        if (IsEmpty()) return -1;
        return queue[front];
    }
    
    public int Rear() {
        if (IsEmpty()) return -1;
        return queue[rear];
    }
    
    public bool IsEmpty() {
        return count == 0;
    }
    
    public bool IsFull() {
        return count == capacity;
    }
}