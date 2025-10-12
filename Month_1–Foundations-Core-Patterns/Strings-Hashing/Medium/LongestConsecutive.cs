public class Solution {
    public int LongestConsecutive(int[] nums) {
        HashSet<int> lookup = new HashSet<int>(nums);
        int length = 0,maxLength=0;

        foreach(int num in lookup)
        {
            if(!lookup.Contains(num-1))
            {
                int currentNum = num;
                length=1;
                while(lookup.Contains(currentNum+1))
                {
                    length++;
                    currentNum++;
                }
                if(length>maxLength)
                    maxLength = length;
            }
        }
        return maxLength;
    }
}