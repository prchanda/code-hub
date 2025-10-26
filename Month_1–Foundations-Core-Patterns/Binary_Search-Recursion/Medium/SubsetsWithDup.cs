public class Solution {
    public IList<IList<int>> SubsetsWithDup(int[] nums) {
        Array.Sort(nums);
        IList<int> current = new List<int>();
        IList<IList<int>> result = new List<IList<int>>();
        BackTrack(nums, 0, current, result);
        return result;
    }

    private void BackTrack(int[] nums, int start, IList<int> current, IList<IList<int>> result)
    {
        result.Add(new List<int>(current));

        for(int i=start; i<nums.Length; i++)
        {
            if(i>start && nums[i]==nums[i-1])
                continue;
            current.Add(nums[i]);
            BackTrack(nums, i+1, current, result);
            current.RemoveAt(current.Count-1);
        }
    }
}