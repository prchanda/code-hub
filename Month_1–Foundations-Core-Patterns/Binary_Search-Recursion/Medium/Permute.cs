public class Solution
{
    public IList<IList<int>> Permute(int[] nums)
    {
        IList<IList<int>> result = new List<IList<int>>();
        IList<int> current = new List<int>();
        bool[] used = new bool[nums.Length];
        BackTrack(nums, used, current, result);
        return result;
    }

    private void BackTrack(int[] nums, bool[] used, IList<int> current, IList<IList<int>> result)
    {
        if (current.Count == nums.Length)
        {
            result.Add(new List<int>(current));
            return;
        }

        for (int i = 0; i < nums.Length; i++)
        {
            if (used[i])
                continue;
            used[i] = true;
            current.Add(nums[i]);
            BackTrack(nums, used, current, result);
            used[i] = false;
            current.RemoveAt(current.Count - 1);
        }
    }
}

/*  
    Time Complexity: O(n * n!) - There are n! permutations and generating each permutation takes O(n) time.
    Space Complexity: O(n) - The maximum depth of the recursion tree can go up to n, and we also use O(n) space for the 'used' array.
*/