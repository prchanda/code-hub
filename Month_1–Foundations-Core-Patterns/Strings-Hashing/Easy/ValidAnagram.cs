public class Solution
{
    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length)
            return false;
        Dictionary<char, int> lookup = new Dictionary<char, int>();

        foreach (char c in s)
        {
            lookup[c] = lookup.GetValueOrDefault(c, 0) + 1;
        }

        foreach (char c in t)
        {
            if (!lookup.ContainsKey(c) || lookup[c] == 0)
                return false;
            lookup[c]--;
        }
        return true;
    }
}

/*  
    Time Complexity: O(n) - We traverse both strings s and t once.
    Space Complexity: O(1) - We use a dictionary to store character counts, but the size of the dictionary is limited by the character set (e.g., 26 for lowercase English letters).
*/