public class Solution
{
    public IList<IList<int>> SubsetsWithDup(int[] nums)
    {
        Array.Sort(nums);
        IList<int> current = new List<int>();
        IList<IList<int>> result = new List<IList<int>>();
        BackTrack(nums, 0, current, result);
        return result;
    }

    private void BackTrack(int[] nums, int start, IList<int> current, IList<IList<int>> result)
    {
        result.Add(new List<int>(current));

        for (int i = start; i < nums.Length; i++)
        {
            if (i > start && nums[i] == nums[i - 1])
                continue;
            current.Add(nums[i]);
            BackTrack(nums, i + 1, current, result);
            current.RemoveAt(current.Count - 1);
        }
    }
}

/*  
    Time Complexity: O(2^n * n) - where n is the number of elements in nums. There are 2^n subsets, and copying each subset to the result takes O(n) time in the worst case.
    Space Complexity: O(n) - The maximum depth of the recursion tree can go up to n, and we also use O(n) space for the current subset.
*/