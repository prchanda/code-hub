public class Solution
{
    public int EvalRPN(string[] tokens)
    {
        Stack<int> stack = new Stack<int>();
        foreach (var token in tokens)
        {
            switch (token)
            {
                case "+":
                    stack.Push(stack.Pop() + stack.Pop());
                    break;
                case "-":
                    {
                        int b = stack.Pop();
                        int a = stack.Pop();
                        stack.Push(a - b);
                    }
                    break;
                case "*":
                    stack.Push(stack.Pop() * stack.Pop());
                    break;
                case "/":
                    {
                        int b = stack.Pop();
                        int a = stack.Pop();
                        stack.Push(a / b);
                    }
                    break;
                default:
                    stack.Push(int.Parse(token));
                    break;
            }
        }
        return stack.Pop();
    }
}

/*  
    Time Complexity: O(n) - We traverse the tokens array once.
    Space Complexity: O(n) - In the worst case, we may push all numbers onto the stack.
*/