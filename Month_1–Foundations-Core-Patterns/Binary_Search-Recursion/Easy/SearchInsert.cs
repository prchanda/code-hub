public class Solution {
    public int SearchInsert(int[] nums, int target) {
        int left = 0, right = nums.Length-1, mid=0;

        while(left<=right)
        {
            mid = (left+right)/2;
            if(nums[mid]==target)
                return mid;
            else if(target>nums[mid])
            {
                left=mid+1;
            }
            else
            {
                right=mid-1;
            }
        }
        return left;
    }
}