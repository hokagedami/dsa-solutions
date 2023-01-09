namespace Assessments.Data
{
    public class ListNode
    {
        public int Val;
        public ListNode Next;
        public ListNode(int val=0, ListNode next=null) 
        {
            Val = val;
            Next = next;
        }
    }

    public static class MergeTwoLists
    {
        public static ListNode Solution(ListNode list1, ListNode list2)
        {
            if (list1 == null) return list2;
            if (list2 == null) return list1;
            return list1.Val > list2.Val ? new ListNode(list2.Val, Solution(list2.Next, list1)) 
                : new ListNode(list1.Val, Solution(list2, list1.Next));
        }
    }

    public static class ReverseLinkedList
    {
        public static ListNode Solution(ListNode head)
        {
            ListNode previous = null;
            var current = head;
            while (current != null)
            {
                var next = current.Next;
                current.Next = previous;
                previous = current;
                current = next;
            }
            return previous;
        }
    }

    public static class MiddleNode
    {
        public static ListNode Solution(ListNode head)
        {
            if (head?.Next == null) return head;
            var counter = 0;
            var current = head;
            var next = head.Next;
            while (current.Next != null)
            {
                counter++;
                current = next;
                next = current.Next;
            }
            var mid = (int)Math.Ceiling(counter * 0.5);
            current = head;
            var counterCpy = 1;
            while (counterCpy < mid)
            {
                current = next;
                next = current.Next;
                counterCpy++;
            }
            return counter % 2 == 0 ? current.Next : current;
        }
    }

    public static class DetectCycle
    {
        public static ListNode Solution(ListNode head)
        {
            var nodes = new HashSet<ListNode>();
            var current = head;
            while (current != null)
            {
                if (nodes.Contains(current)) return current;
                nodes.Add(current);
                current = current.Next;
            }
            return null;
        }
    }
}