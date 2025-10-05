public class Solution {
    public int EraseOverlapIntervals(int[][] intervals) {
        int count=0;
        Array.Sort(intervals, (a,b)=>a[1].CompareTo(b[1]));
        int lastEnd = intervals[0][1];

        for(int index=1; index<intervals.Length; index++)
        {
            if(intervals[index][0]<lastEnd)
                count++;
            else
            {
                lastEnd = intervals[index][1];
            }
        }

        return count;
    }
}