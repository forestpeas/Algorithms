namespace Algorithms.DataStructures
{
    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int x)
        {
            val = x;
        }

        public ListNode(int x, ListNode next)
        {
            val = x;
            this.next = next;
        }

        public override string ToString()
        {
            return $"{val} -> {(next == null ? "null" : next.val.ToString())}";
        }
    }
}
