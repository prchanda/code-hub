public class Solution
{
    public bool IsValid(string s)
    {
        Stack<char> stack = new Stack<char>();
        foreach (char ch in s)
        {
            if (ch == '(' || ch == '{' || ch == '[')
                stack.Push(ch);
            else
            {
                if (stack.Count == 0)
                    return false;
                var top = stack.Pop();

                if ((ch == ')' && top != '(') ||
                   (ch == '}' && top != '{') ||
                   (ch == ']' && top != '['))
                    return false;
            }
        }
        return stack.Count == 0;
    }
}

/*  
    Time Complexity: O(n) - We traverse the string s once.
    Space Complexity: O(n) - In the worst case, we may push all opening brackets onto the stack.
*/