public class Solution {
    public int SubarraySum(int[] nums, int k) {
        Dictionary<int, int> prefixSumLookup = new Dictionary<int, int>(){{0,1}};
        int prefixSum = 0, count=0;
        for(int index=0; index<nums.Length; index++)
        {
            prefixSum+=nums[index];
            if(prefixSumLookup.TryGetValue(prefixSum-k, out int frequency))
            {
                count+=frequency;
            }
            prefixSumLookup[prefixSum] = prefixSumLookup.GetValueOrDefault(prefixSum, 0) + 1;
        }
        return count;
    }
}