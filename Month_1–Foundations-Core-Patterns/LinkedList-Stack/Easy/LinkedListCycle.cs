public class Solution
{
    public bool HasCycle(ListNode head)
    {
        ListNode fast = head, slow = head;
        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
            if (slow == fast)
                return true;
        }
        return false;
    }
}

/*  
    Time Complexity: O(n) - We traverse the linked list at most once.
    Space Complexity: O(1) - We use a constant amount of extra space for the two pointers.
*/