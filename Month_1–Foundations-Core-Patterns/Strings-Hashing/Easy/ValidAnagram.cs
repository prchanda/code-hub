public class Solution {
    public bool IsAnagram(string s, string t) {
        if (s.Length != t.Length) 
            return false; 
        Dictionary<char, int> lookup = new Dictionary<char, int>();

        foreach (char c in s) {
            lookup[c] = lookup.GetValueOrDefault(c, 0) + 1;
        }

        foreach (char c in t) {
            if (!lookup.ContainsKey(c) || lookup[c] == 0)
                return false;
            lookup[c]--;
        }
        return true;
    }
}