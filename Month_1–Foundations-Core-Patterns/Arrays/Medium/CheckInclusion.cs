public class Solution {
    public bool CheckInclusion(string s1, string s2) {
        if(s1.Length>s2.Length)
            return false;
        
        int[] s1Count = new int[26];
        int[] s2Count = new int[26];

        for(int index=0; index<s1.Length; index++)
        {
            s1Count[s1[index]-'a']++;
            s2Count[s2[index]-'a']++;
        }

        for(int index=0;index<=s2.Length-s1.Length;index++)
        {
            if(Matches(s1Count,s2Count))
                return true;

            if(index<s2.Length-s1.Length)
            {
                s2Count[s2[index]-'a']--;
                s2Count[s2[index+s1.Length]-'a']++;
            }
        }

        return false;
    }

    private bool Matches(int[] s1Count, int[] s2Count)
    {
        for(int index=0; index<26; index++)
        {
            if(s1Count[index]!=s2Count[index])
                return false;
        }
        return true;
    }
}