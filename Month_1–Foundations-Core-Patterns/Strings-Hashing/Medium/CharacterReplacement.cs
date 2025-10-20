public class Solution {
    public int CharacterReplacement(string s, int k) {
        int left=0, maxLength=0, maxCount=0;
        int[] sCount = new int[26];

        for(int right=0;right<s.Length;right++)
        {
            sCount[s[right]-'A']++;
            maxCount = Math.Max(maxCount, sCount[s[right]-'A']);

            if((right-left+1) - maxCount > k)
            {
                sCount[s[left]-'A']--;
                left++;
            }
            maxLength = Math.Max(maxLength, right-left+1);
        }

        return maxLength;
    }
}