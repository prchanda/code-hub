public class Solution {
    public IList<IList<int>> Subsets(int[] nums) {
        var result = new List<IList<int>>();
        var current = new List<int>();
        GenerateSubsets(0, nums, current, result);
        return result;
    }

    private void GenerateSubsets(int index, int[] nums, List<int> current, IList<IList<int>> result) 
    {
        result.Add(new List<int>(current));

        for (int i = index; i < nums.Length; i++) {
            current.Add(nums[i]);
            GenerateSubsets(i + 1, nums, current, result);
            current.RemoveAt(current.Count - 1);
        }
    }
}