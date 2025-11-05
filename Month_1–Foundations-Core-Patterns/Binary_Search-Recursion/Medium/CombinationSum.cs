public class Solution
{
    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        List<IList<int>> result = new List<IList<int>>();
        Array.Sort(candidates);
        Backtrack(candidates, target, 0, new List<int>(), result);
        return result;
    }

    private void Backtrack(int[] candidates, int target, int start, List<int> current, List<IList<int>> result)
    {
        if (target == 0)
        {
            result.Add(new List<int>(current));
            return;
        }

        for (int i = start; i < candidates.Length; i++)
        {
            if (candidates[i] > target)
                break;

            current.Add(candidates[i]);
            Backtrack(candidates, target - candidates[i], i, current, result);
            current.RemoveAt(current.Count - 1);
        }
    }
}

/*  
    Time Complexity: O(2^t * k) - where t is the target value and k is the average length of combinations. In the worst case, we explore all combinations.
    Space Complexity: O(k) - The maximum depth of the recursion tree can go up to k, where k is the target divided by the smallest candidate.
*/