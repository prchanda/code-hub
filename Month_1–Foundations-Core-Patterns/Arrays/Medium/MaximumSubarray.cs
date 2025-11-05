public class Solution
{
    public int MaxSubArray(int[] nums)
    {
        int currentSum = nums[0], maxSum = nums[0];

        for (int index = 1; index < nums.Length; index++)
        {
            currentSum = Math.Max(nums[index], currentSum + nums[index]);
            maxSum = Math.Max(maxSum, currentSum);
        }

        return maxSum;
    }
}

/*  
    Time Complexity: O(n) - We traverse the nums array once.
    Space Complexity: O(1) - We use a constant amount of extra space.
*/