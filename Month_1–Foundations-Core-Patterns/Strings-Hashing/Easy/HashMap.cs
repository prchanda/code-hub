public class Node
{
    public int Key { get; set; }
    public int Value { get; set; }

    public Node(int key, int value)
    {
        Key = key;
        Value = value;
    }
}

public class MyHashMap
{
    private const int SIZE = 1000;
    private List<Node>[] buckets;

    public MyHashMap()
    {
        buckets = new List<Node>[SIZE];
    }

    private int GetHash(int key)
    {
        return key % SIZE;
    }

    public void Put(int key, int value)
    {
        int index = GetHash(key);
        if (buckets[index] == null)
        {
            buckets[index] = new List<Node>();
        }

        foreach (var node in buckets[index])
        {
            if (node.Key == key)
            {
                // ✅ Update in place
                node.Value = value;
                return;
            }
        }

        // Key not found, add new
        buckets[index].Add(new Node(key, value));
    }

    public int Get(int key)
    {
        int index = GetHash(key);
        if (buckets[index] == null)
            return -1;

        foreach (var node in buckets[index])
        {
            if (node.Key == key)
                return node.Value;
        }

        return -1;
    }

    public void Remove(int key)
    {
        int index = GetHash(key);
        if (buckets[index] == null)
            return;

        for (int i = 0; i < buckets[index].Count; i++)
        {
            if (buckets[index][i].Key == key)
            {
                buckets[index].RemoveAt(i);
                return;
            }
        }
    }
}
