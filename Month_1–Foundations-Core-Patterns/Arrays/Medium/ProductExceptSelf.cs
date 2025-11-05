public class Solution
{
    public int[] ProductExceptSelf(int[] nums)
    {
        int leftRunningProduct = 1, rightRunningProduct = 1;
        int[] output = new int[nums.Length];
        for (int index = 0; index < nums.Length; index++)
        {
            output[index] = leftRunningProduct;
            leftRunningProduct *= nums[index];
        }
        for (int index = nums.Length - 1; index >= 0; index--)
        {
            output[index] = output[index] * rightRunningProduct;
            rightRunningProduct *= nums[index];
        }
        return output;
    }
}

/*  
    Time Complexity: O(n) - We traverse the nums array twice.
    Space Complexity: O(1) - We use a constant amount of extra space for the output array.
*/