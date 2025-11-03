public class Solution {
    public IList<string> GenerateParenthesis(int n) {
        string current = "";
        IList<string> result = new List<string>();
        BackTrack(current, result, 0, 0, n);
        return result;
    }

    private void BackTrack(string current, IList<string> result, int open, int close, int max)
    {
        if(current.Length == max*2)
        {
            result.Add(current);
            return;
        }

        if(open < max)
        {
            BackTrack(current+"(",result,open+1,close,max);
        }

        if(close < open)
        {
            BackTrack(current+")",result,open,close+1,max);
        }
    }
}