public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        Dictionary<int, int> lookup = new Dictionary<int, int>();
        var result = new int[2];
        for(int index=0; index<nums.Length; index++)
        {
            int complement = target - nums[index];
            if(lookup.ContainsKey(complement))
            {
                result = new int[2]{index, lookup[complement]};
                break;
            }
            else if(!lookup.ContainsKey(nums[index]))
            {
                lookup.Add(nums[index], index);
            }
        }
        return result;
    }
}