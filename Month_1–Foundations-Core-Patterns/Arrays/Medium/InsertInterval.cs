public class Solution {
    public int[][] Insert(int[][] intervals, int[] newInterval) {
        int index=0, n=intervals.Length;
        List<int[]> mergedIntervals = new List<int[]>();
        while(index<n && intervals[index][1]<newInterval[0])
        {
            mergedIntervals.Add(intervals[index]);
            index++;
        }
        while(index<n && intervals[index][0]<=newInterval[1])
        {
            newInterval[0] = Math.Min(newInterval[0],intervals[index][0]);
            newInterval[1] = Math.Max(newInterval[1],intervals[index][1]);
            index++;
        }
        mergedIntervals.Add(newInterval);
        while(index<n)
        {
            mergedIntervals.Add(intervals[index]);
            index++;
        }
        return mergedIntervals.ToArray();
    }
}