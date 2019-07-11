using System.Text;

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
            StringBuilder sb = new StringBuilder();
            sb.Append(val);
            for (var node = next; node != null; node = node.next)
            {
                sb.Append($" -> {node.val}");
            }
            return sb.ToString();
        }
    }
}
