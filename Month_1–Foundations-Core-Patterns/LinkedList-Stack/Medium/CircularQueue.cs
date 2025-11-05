public class MyCircularQueue
{
    private int[] queue;
    private int front;
    private int rear;
    private int count;
    private int capacity;

    public MyCircularQueue(int k)
    {
        queue = new int[k];
        capacity = k;
        front = 0;
        rear = -1;
        count = 0;
    }

    public bool EnQueue(int value)
    {
        if (IsFull()) return false;
        rear = (rear + 1) % capacity;
        queue[rear] = value;
        count++;
        return true;
    }

    public bool DeQueue()
    {
        if (IsEmpty()) return false;
        front = (front + 1) % capacity;
        count--;
        return true;
    }

    public int Front()
    {
        if (IsEmpty()) return -1;
        return queue[front];
    }

    public int Rear()
    {
        if (IsEmpty()) return -1;
        return queue[rear];
    }

    public bool IsEmpty()
    {
        return count == 0;
    }

    public bool IsFull()
    {
        return count == capacity;
    }
}

/*  
    Time Complexity: 
        EnQueue: O(1) - Each enqueue operation takes constant time.
        DeQueue: O(1) - Each dequeue operation takes constant time.
        Front: O(1) - Accessing the front element takes constant time.
        Rear: O(1) - Accessing the rear element takes constant time.
        IsEmpty: O(1) - Checking if the queue is empty takes constant time.
        IsFull: O(1) - Checking if the queue is full takes constant time.

    Space Complexity: O(k) - where k is the capacity of the circular queue. We use an array of size k to store the elements.
*/