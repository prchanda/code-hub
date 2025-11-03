public class Solution {
    private static readonly Dictionary<char, string> phoneMap = new Dictionary<char, string> {
        {'2', "abc"}, {'3', "def"}, {'4', "ghi"},
        {'5', "jkl"}, {'6', "mno"}, {'7', "pqrs"},
        {'8', "tuv"}, {'9', "wxyz"}
    };

    public IList<string> LetterCombinations(string digits) {
        List<string> result = new List<string>();
        if (string.IsNullOrEmpty(digits))
            return result;

        Backtrack(result, digits, 0, "");
        return result;
    }

    private void Backtrack(List<string> result, string digits, int index, string current) {
        if (index == digits.Length) {
            result.Add(current);
            return;
        }

        string letters = phoneMap[digits[index]];
        foreach (char letter in letters) {
            Backtrack(result, digits, index + 1, current + letter);
        }
    }
}
