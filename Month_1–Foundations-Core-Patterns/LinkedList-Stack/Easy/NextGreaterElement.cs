public class Solution
{
    public int[] NextGreaterElement(int[] nums1, int[] nums2)
    {
        var nextGreater = new Dictionary<int, int>();
        var stack = new Stack<int>();

        foreach (var num in nums2)
        {
            while (stack.Count > 0 && stack.Peek() < num)
            {
                nextGreater[stack.Pop()] = num;
            }
            stack.Push(num);
        }

        // Remaining elements have no next greater, implicitly -1
        int[] result = new int[nums1.Length];
        for (int i = 0; i < nums1.Length; i++)
        {
            result[i] = nextGreater.ContainsKey(nums1[i]) ? nextGreater[nums1[i]] : -1;
        }

        return result;
    }
}

/*  
    Time Complexity: O(n + m) - where n is the length of nums1 and m is the length of nums2. We traverse nums2 once and then nums1 once.
    Space Complexity: O(m) - We use a dictionary to store the next greater elements for elements in nums2.
*/