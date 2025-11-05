public class Solution
{
    public IList<int> FindAnagrams(string s, string p)
    {
        int[] sCount = new int[26];
        int[] pCount = new int[26];
        List<int> startIndices = new List<int>();
        if (p.Length > s.Length)
            return startIndices;

        for (int index = 0; index < p.Length; index++)
        {
            sCount[s[index] - 'a']++;
            pCount[p[index] - 'a']++;
        }

        for (int index = 0; index <= s.Length - p.Length; index++)
        {
            if (Matches(sCount, pCount))
            {
                startIndices.Add(index);
            }
            if (index < s.Length - p.Length)
            {
                sCount[s[index] - 'a']--;
                sCount[s[index + p.Length] - 'a']++;
            }
        }

        return startIndices;
    }

    private bool Matches(int[] sCount, int[] pCount)
    {
        for (int index = 0; index < 26; index++)
        {
            if (sCount[index] != pCount[index])
                return false;
        }
        return true;
    }
}

/*  
    Time Complexity: O(n) - We traverse the string s once.
    Space Complexity: O(1) - We use a constant amount of extra space for the frequency arrays.
*/