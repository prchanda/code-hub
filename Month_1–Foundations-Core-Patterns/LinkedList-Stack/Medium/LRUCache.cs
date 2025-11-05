public class LRUCache
{
    private readonly int capacity;
    private readonly Dictionary<int, LinkedListNode<KeyValuePair<int, int>>> cache;
    private readonly LinkedList<KeyValuePair<int, int>> lruList;

    public LRUCache(int capacity)
    {
        this.capacity = capacity;
        cache = new Dictionary<int, LinkedListNode<KeyValuePair<int, int>>>(capacity);
        lruList = new LinkedList<KeyValuePair<int, int>>();
    }

    public int Get(int key)
    {
        if (!cache.ContainsKey(key))
            return -1;

        var node = cache[key];
        lruList.Remove(node);
        lruList.AddFirst(node);
        return node.Value.Value;
    }

    public void Put(int key, int value)
    {
        if (cache.ContainsKey(key))
        {
            var node = cache[key];
            lruList.Remove(node);
        }
        else if (cache.Count == capacity)
        {
            var lastNode = lruList.Last;
            cache.Remove(lastNode.Value.Key);
            lruList.RemoveLast();
        }

        var newNode = new LinkedListNode<KeyValuePair<int, int>>(
            new KeyValuePair<int, int>(key, value)
        );

        lruList.AddFirst(newNode);
        cache[key] = newNode;
    }
}

/*  
    Time Complexity: 
        Get: O(1) - Both dictionary lookup and linked list operations (remove and add) are O(1).
        Put: O(1) - Dictionary operations and linked list operations are O(1).

    Space Complexity: O(capacity) - We store up to 'capacity' number of items in the cache.
*/