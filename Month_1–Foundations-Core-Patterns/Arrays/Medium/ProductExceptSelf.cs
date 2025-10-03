public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        int leftRunningProduct = 1, rightRunningProduct = 1;
        int[] output = new int[nums.Length];
        for(int index=0; index<nums.Length; index++)
        {
            output[index] = leftRunningProduct;
            leftRunningProduct*=nums[index];
        }
        for(int index=nums.Length-1; index>=0; index--)
        {
            output[index] = output[index] * rightRunningProduct;
            rightRunningProduct*=nums[index];
        }
        return output;
    }
}