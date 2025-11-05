public class Solution
{
    public int[] TwoSum(int[] numbers, int target)
    {
        int[] output = new int[2];
        for (int left = 0, right = numbers.Length - 1; left < right;)
        {
            int sum = numbers[left] + numbers[right];
            if (sum == target)
            {
                output[0] = left + 1;
                output[1] = right + 1;
                break;
            }
            else if (sum < target)
                left++;
            else
                right--;
        }

        return output;
    }
}

/*  
    Time Complexity: O(n) - We traverse the numbers array once.
    Space Complexity: O(1) - We use a constant amount of extra space.
*/