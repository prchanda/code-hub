public class Solution {
    public void SetZeroes(int[][] matrix) {
        int rows = matrix.Length, cols = matrix[0].Length;
        bool hasFirstRowZeros = false, hasFirstColumnZeros = false;

        for(int index=0;index<cols; index++)
        {
            if(matrix[0][index]==0)
            {
                hasFirstRowZeros = true;
                break;
            }
        }

        for(int index=0;index<rows; index++)
        {
            if(matrix[index][0]==0)
            {
                hasFirstColumnZeros = true;
                break;
            }
        }

        for(int i=1; i<rows; i++)
        {
            for(int j=1; j<cols; j++)
            {
                if(matrix[i][j]==0)
                {
                    matrix[0][j]=0;
                    matrix[i][0]=0;
                }
            }
        }

        for(int i=1; i<rows; i++)
        {
            for(int j=1; j<cols; j++)
            {
                if(matrix[0][j]==0 || matrix[i][0]==0)
                {
                    matrix[i][j]=0;
                }
            }
        }

        if(hasFirstRowZeros)
        {
            for(int i=0; i<cols; i++)
            {
                matrix[0][i]=0;
            }
        }

        if(hasFirstColumnZeros)
        {
            for(int i=0; i<rows; i++)
            {
                matrix[i][0]=0;
            }
        }
    }
}