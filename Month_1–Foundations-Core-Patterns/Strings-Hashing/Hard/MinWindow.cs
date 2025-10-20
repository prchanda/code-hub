public class Solution {
    public string MinWindow(string s, string t) {
        if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t))
            return "";

        Dictionary<char, int> targetCount = new Dictionary<char, int>();
        foreach (char c in t)
            targetCount[c] = targetCount.GetValueOrDefault(c, 0) + 1;

        int need = targetCount.Count;
        int have = 0;
        Dictionary<char, int> windowCount = new Dictionary<char, int>();

        int l = 0, r = 0;
        int[] ans = { -1, 0, 0 }; // length, left, right

        while (r < s.Length) {
            char c = s[r];
            windowCount[c] = windowCount.GetValueOrDefault(c, 0) + 1;

            if (targetCount.ContainsKey(c) && windowCount[c] == targetCount[c])
                have++;

            // Try to contract the window till it's no longer valid
            while (l <= r && have == need) {
                if (ans[0] == -1 || r - l + 1 < ans[0])
                    ans = new int[] { r - l + 1, l, r };

                char leftChar = s[l];
                windowCount[leftChar]--;
                if (targetCount.ContainsKey(leftChar) && windowCount[leftChar] < targetCount[leftChar])
                    have--;

                l++;
            }
            r++;
        }

        return ans[0] == -1 ? "" : s.Substring(ans[1], ans[0]);
    }
}
