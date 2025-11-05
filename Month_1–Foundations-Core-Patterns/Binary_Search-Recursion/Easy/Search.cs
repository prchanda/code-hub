public class Solution
{
    public int Search(int[] nums, int target)
    {
        int left = 0, right = nums.Length - 1;

        while (left <= right)
        {
            int mid = (left + right) / 2;
            if (nums[mid] == target)
                return mid;
            else if (nums[mid] < target)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return -1;
    }
}

/*  
    Time Complexity: O(log n) - We halve the search space with each iteration.
    Space Complexity: O(1) - We use a constant amount of extra space.
*/