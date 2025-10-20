public class Solution {
    public string LongestPalindrome(string s) {
        if (string.IsNullOrEmpty(s)) return "";

        int start = 0, end = 0;

        for (int i = 0; i < s.Length; i++) {
            // Case 1: Odd length palindrome (center at i)
            int len1 = ExpandFromCenter(s, i, i);

            // Case 2: Even length palindrome (center between i and i+1)
            int len2 = ExpandFromCenter(s, i, i + 1);

            int len = Math.Max(len1, len2);

            if (len > end - start) {
                start = i - (len - 1) / 2;
                end = i + len / 2;
            }
        }

        return s.Substring(start, end - start + 1);
    }

    private int ExpandFromCenter(string s, int left, int right) {
        while (left >= 0 && right < s.Length && s[left] == s[right]) {
            left--;
            right++;
        }
        // when loop breaks, left and right have gone one step too far
        return right - left - 1;
    }
}