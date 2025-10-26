public class Solution {
    public IList<IList<int>> Combine(int n, int k) {
        var result = new List<IList<int>>();
        Backtrack(1, new List<int>(), result, n, k);
        return result;
    }

    private void Backtrack(int start, List<int> current, IList<IList<int>> result, int n, int k) {
        // Base case: when we have k numbers, add to result
        if (current.Count == k) {
            result.Add(new List<int>(current));
            return;
        }

        // Try all remaining numbers
        for (int i = start; i <= n; i++) {
            current.Add(i);             // Choose
            Backtrack(i + 1, current, result, n, k);  // Explore next numbers
            current.RemoveAt(current.Count - 1);      // Un-choose (backtrack)
        }
    }
}