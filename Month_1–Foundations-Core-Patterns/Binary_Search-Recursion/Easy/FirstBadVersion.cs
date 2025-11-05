public class Solution : VersionControl
{
    public int FirstBadVersion(int n)
    {
        int left = 1;
        int right = n;

        while (left < right)
        {
            int mid = left + (right - left) / 2;

            if (IsBadVersion(mid))
                right = mid;       // move left to find earlier bad version
            else
                left = mid + 1;    // skip good versions
        }

        return left; // or right — both point to the first bad version
    }
}

/*  
    Time Complexity: O(log n) - We halve the search space with each iteration.
    Space Complexity: O(1) - We use a constant amount of extra space.
*/