public class Solution {
    public bool HasCycle(ListNode head) {
        ListNode fast = head, slow = head;
        while(fast!=null && fast.next!=null)
        {
            slow=slow.next;
            fast=fast.next.next;
            if(slow==fast)
                return true;
        }
        return false;   
    }
}