public class Solution {
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        ListNode dummy = new ListNode(0, head);
        ListNode fast=dummy, slow=dummy;
        for(int index=0;index<=n;index++)
        {
            fast=fast.next;
        }
        while(fast!=null && slow!=null)
        {
            slow=slow.next;
            fast=fast.next;
        }
        slow.next=slow.next.next;
        return dummy.next;
    }
}