public class Solution {
    public int LengthOfLongestSubstring(string s) {
        if(string.IsNullOrEmpty(s))
            return 0;
        HashSet<char> lookup = new HashSet<char>();
        int left = 0, maxLength = 0;
        for(int right =0; right<s.Length; right++)
        {
            while(lookup.Contains(s[right]))
            {
                lookup.Remove(s[left]);
                left++;
            }
            lookup.Add(s[right]);
            maxLength = Math.Max(maxLength, lookup.Count);
        }
        return maxLength;
    }
}