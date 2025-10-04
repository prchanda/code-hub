public class Solution {
    public IList<int> SpiralOrder(int[][] matrix) {
        IList<int> output = new List<int>();
        int top=0,left=0,right=matrix[0].Length-1,bottom=matrix.Length-1;        

        while(top<=bottom && left<=right)
        {
            for(int i=left;i<=right;i++)
            {
                output.Add(matrix[top][i]);
            }
            top++;
            
            for(int i=top;i<=bottom;i++)
            {
                output.Add(matrix[i][right]);
            }
            right--;

            if(top<=bottom)
            {
                for(int i=right;i>=left;i--)
                {
                    output.Add(matrix[bottom][i]);
                }
                bottom--;
            }

            if(left<=right)
            {
                for(int i=bottom;i>=top;i--)
                {
                    output.Add(matrix[i][left]);
                }
                left++;
            }
        }

        return output;
    }
}