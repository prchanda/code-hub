public class Solution {
    public IList<IList<int>> ThreeSum(int[] nums) {
        IList<IList<int>> output = new List<IList<int>>();
        Array.Sort(nums);
        for(int index=0; index<nums.Length-2; index++)
        {
            if(index>0 && nums[index]==nums[index-1])
                continue;
            int left = index + 1;
            int right = nums.Length-1;
            while(left<right)
            {
                int sum = nums[index]+nums[left]+nums[right];
                if(sum == 0)
                {
                    output.Add(new List<int>{nums[index], nums[left], nums[right]});
                    left++;
                    right--;

                    while(left<right && nums[left]==nums[left-1])
                        left++;
                    while(left<right && nums[right]==nums[right+1])
                        right--;
                }
                else if(sum<0)
                    left++;
                else
                    right--;
            }
        }        
        return output;
    }
}