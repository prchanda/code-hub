public class Solution
{
    public ListNode ReverseList(ListNode head)
    {
        ListNode current = head;
        ListNode prev = null;

        while (current != null)
        {
            ListNode next = current.next;
            current.next = prev;
            prev = current;
            current = next;
        }

        return prev;
    }
}

// Recursive version

public class Solution {
    public ListNode ReverseList(ListNode head) {
        if(head == null || head.next == null)
            return head;

        ListNode node = ReverseList(head.next);
        head.next.next = head;
        head.next = null;
        return node;
    }
}