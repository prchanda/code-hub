public class Solution {
    public int MinSubArrayLen(int target, int[] nums) {
        int left=0, explorer=0, currentSum=0, minLength=Int32.MaxValue;
        for(int right=0;right<nums.Length;right++)
        {
            currentSum+=nums[right];
            while(currentSum>=target)
            {
                minLength = Math.Min(minLength, right-left+1);
                currentSum-=nums[left];
                left++;
            }
        }
        return minLength == Int32.MaxValue ? 0 : minLength;
    }
}