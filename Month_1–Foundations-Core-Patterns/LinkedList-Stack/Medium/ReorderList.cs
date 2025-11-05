public class Solution
{
    public void ReorderList(ListNode head)
    {
        if (head == null || head.next == null)
            return;

        ListNode fast = head, slow = head;
        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }

        ListNode second = slow.next;
        slow.next = null;
        second = ReverseList(second);

        ListNode first = head;
        while (second != null)
        {
            ListNode temp1 = first.next;
            ListNode temp2 = second.next;

            first.next = second;
            second.next = temp1;

            first = temp1;
            second = temp2;
        }
    }

    private ListNode ReverseList(ListNode head)
    {
        if (head == null || head.next == null)
            return head;

        ListNode node = ReverseList(head.next);
        head.next.next = head;
        head.next = null;
        return node;
    }
}

/*  
    Time Complexity: O(n) - We traverse the linked list a constant number of times, where n is the number of nodes in the list.
    Space Complexity: O(1) - We use a constant amount of extra space.
*/