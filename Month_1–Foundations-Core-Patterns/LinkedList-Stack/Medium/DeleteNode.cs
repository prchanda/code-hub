public class Solution
{
    public void DeleteNode(ListNode node)
    {
        node.val = node.next.val;
        node.next = node.next.next;
    }
}

/*  
    Time Complexity: O(1) - We perform a constant number of operations.
    Space Complexity: O(1) - We use a constant amount of extra space.
*/