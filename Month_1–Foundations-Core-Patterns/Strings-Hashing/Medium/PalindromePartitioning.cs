public class Solution {
    public IList<IList<string>> Partition(string s) {
        var result = new List<IList<string>>();
        var currentList = new List<string>();
        Backtrack(s, 0, currentList, result);
        return result;
    }

    private void Backtrack(string s, int start, List<string> current, IList<IList<string>> result) {
        // Base case: reached end of string
        if (start == s.Length) {
            result.Add(new List<string>(current)); // add a copy
            return;
        }

        // Explore all possible substrings
        for (int end = start; end < s.Length; end++) {
            if (IsPalindrome(s, start, end)) {
                // choose
                current.Add(s.Substring(start, end - start + 1));

                // explore
                Backtrack(s, end + 1, current, result);

                // un-choose (backtrack)
                current.RemoveAt(current.Count - 1);
            }
        }
    }

    private bool IsPalindrome(string s, int left, int right) {
        while (left < right) {
            if (s[left++] != s[right--])
                return false;
        }
        return true;
    }
}