public class Solution
{
    public int FindMaxLength(int[] nums)
    {
        // Dictionary to store (prefix sum) => first index where it occurred
        Dictionary<int, int> map = new Dictionary<int, int>();
        map[0] = -1; // sum 0 occurs at index -1

        int sum = 0;
        int maxLen = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            // Treat 0 as -1
            sum += nums[i] == 0 ? -1 : 1;

            if (map.ContainsKey(sum))
            {
                // Found a previous prefix sum -> subarray sum is 0
                maxLen = Math.Max(maxLen, i - map[sum]);
            }
            else
            {
                // Store the first occurrence of this sum
                map[sum] = i;
            }
        }

        return maxLen;
    }
}

/*  
    Time Complexity: O(n) - We traverse the nums array once.
    Space Complexity: O(n) - In the worst case, we may store all prefix sums in the dictionary.
*/