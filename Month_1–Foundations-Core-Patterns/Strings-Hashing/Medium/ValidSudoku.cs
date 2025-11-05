public class Solution
{
    public bool IsValidSudoku(char[][] board)
    {
        HashSet<string> lookup = new HashSet<string>();

        for (int row = 0; row < board.Length; row++)
        {
            for (int col = 0; col < board[row].Length; col++)
            {
                char number = board[row][col];
                if (number != '.')
                {
                    if (lookup.Contains($"{number} in row {row}") ||
                        lookup.Contains($"{number} in col {col}") ||
                        lookup.Contains($"{number} in block {row / 3},{col / 3}"))
                    {
                        return false;
                    }
                    else
                    {
                        lookup.Add($"{number} in row {row}");
                        lookup.Add($"{number} in col {col}");
                        lookup.Add($"{number} in block {row / 3},{col / 3}");
                    }
                }
            }
        }

        return true;
    }
}

/*  
    Time Complexity: O(1) - The board size is fixed (9x9), so the time complexity is constant.
    Space Complexity: O(1) - The maximum number of entries in the hash set is fixed (at most 243), so the space complexity is constant.
*/