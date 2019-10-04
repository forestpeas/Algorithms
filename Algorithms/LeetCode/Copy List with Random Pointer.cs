namespace Algorithms.LeetCode
{
    /* 138. Copy List with Random Pointer
     * 
     * A linked list is given such that each node contains an additional random pointer
     * which could point to any node in the list or null. Return a deep copy of the list.
     */
    public class CopyListWithRandomPointer
    {
        public Node CopyRandomList(Node head)
        {
            // The given linked list has no cycle.
            // In order to save the mapping of old node to new, set node.next to its copy, like this:
            // A    B    C
            // ↓ ↗ ↓ ↗ ↓
            // A'   B'   C'
            // Then use this mapping to set "random" of the new nodes.
            // Finally, "separate" the old list and the new list.
            for (Node node = head; node != null;)
            {
                Node newNode = new Node() { val = node.val };
                Node next = node.next;
                node.next = newNode; // Save the mapping of old to new.
                newNode.next = next;
                node = next;
            }

            for (Node node = head; node != null; node = node.next.next)
            {
                Node newNode = node.next;
                newNode.random = node.random?.next; // node.random.next is the copy of node.random.
            }

            Node newHead = head?.next;
            Node prevNewNode = new Node();
            for (Node node = head; node != null;)
            {
                Node newNode = node.next;
                Node next = newNode.next;
                prevNewNode.next = newNode; // "Restore" the copy.
                prevNewNode = newNode;
                node.next = next; // Restore the original.
                node = next;
            }

            return newHead;
        }

        public class Node
        {
            public int val;
            public Node next;
            public Node random;

            public Node() { }
            public Node(int _val, Node _next, Node _random)
            {
                val = _val;
                next = _next;
                random = _random;
            }
        }
    }
}
