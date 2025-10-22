public class Solution
{
    public int FindMin(int[] nums)
    {
        int left = 0;
        int right = nums.Length - 1;

        while (left < right)
        {
            int mid = left + (right - left) / 2;

            // If mid element is greater than rightmost element,
            // then the minimum is to the right of mid
            if (nums[mid] > nums[right])
                left = mid + 1;
            else
                right = mid;  // minimum is at mid or to its left
        }

        // left == right -> minimum element
        return nums[left];
    }
}
