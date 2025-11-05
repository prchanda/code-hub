public class Solution
{
    public void Rotate(int[][] matrix)
    {
        int n = matrix.GetLength(0);

        for (int row = 0; row < n; row++)
        {
            for (int col = row; col < n; col++)
            {
                int temp = matrix[row][col];
                matrix[row][col] = matrix[col][row];
                matrix[col][row] = temp;
            }
        }

        for (int row = 0; row < n; row++)
        {
            Array.Reverse(matrix[row]);
        }
    }
}

/*  
    Time Complexity: O(n^2) - We traverse the n x n matrix twice.
    Space Complexity: O(1) - We perform the rotation in place without using extra space.
*/