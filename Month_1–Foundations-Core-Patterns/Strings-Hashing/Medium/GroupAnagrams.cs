public class Solution {
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        Dictionary<string, IList<string>> lookup = new Dictionary<string, IList<string>>();

        foreach (var str in strs) {
            int[] charCount = new int[26];
            foreach (char c in str) 
                charCount[c - 'a']++;
                
            string key = string.Join("#", charCount);

            if (!lookup.ContainsKey(key))
                lookup[key] = new List<string> { str };
            else
                lookup[key].Add(str);
        }

        return lookup.Values.ToList();
    }
}