public class Solution
{
    public int RemoveDuplicates(int[] nums)
    {
        int k = 1;
        int scanElement = nums[k - 1];
        for (int index = 1; index < nums.Length; index++)
        {
            if (scanElement != nums[index])
            {
                scanElement = nums[index];
                nums[k] = scanElement;
                k++;
            }
        }
        return k;
    }
}

/*  
    Time Complexity: O(n) - We traverse the array once.
    Space Complexity: O(1) - We use a constant amount of extra space.
*/