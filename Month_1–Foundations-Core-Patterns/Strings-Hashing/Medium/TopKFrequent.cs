public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        Dictionary<int,int> frequency = new Dictionary<int,int>();
        foreach(int num in nums)
        {
            frequency[num] = frequency.GetValueOrDefault(num, 0)+1;
        }

        PriorityQueue<int,int> pq = new PriorityQueue<int,int>();
        foreach(var kvp in frequency)
        {
            pq.Enqueue(kvp.Key, kvp.Value);
            if(pq.Count>k)
            {
                pq.Dequeue();
            }
        }

        return pq.UnorderedItems.Select(x=>x.Element).ToArray();
    }
}