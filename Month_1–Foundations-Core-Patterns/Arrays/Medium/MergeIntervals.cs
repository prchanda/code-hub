public class Solution {
    public int[][] Merge(int[][] intervals) {
        Array.Sort(intervals, (a,b)=>a[0].CompareTo(b[0]));
        List<int[]> mergedIntervals = new List<int[]>();
        int[] currentInterval = intervals[0];

        foreach(var interval in intervals)
        {
            if(interval[0]<=currentInterval[1])
                currentInterval[1] = Math.Max(currentInterval[1], interval[1]);
            else
            {
                mergedIntervals.Add(currentInterval);
                currentInterval = interval;
            } 
        }
        mergedIntervals.Add(currentInterval);
        return mergedIntervals.ToArray();
    }
}