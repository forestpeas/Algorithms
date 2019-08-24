namespace Algorithms.LeetCode
{
    /* 117. Populating Next Right Pointers in Each Node II
     * 
     * Given a binary tree
     * 
     * struct Node {
     *   int val;
     *   Node *left;
     *   Node *right;
     *   Node *next;
     * }
     * 
     * Populate each next pointer to point to its next right node.
     * If there is no next right node, the next pointer should be set to NULL.
     * 
     * Initially, all next pointers are set to NULL.
     * 
     * For illustration and more clarifications: https://leetcode.com/problems/populating-next-right-pointers-in-each-node-ii/.
     */
    public class PopulatingNextRightPointersInEachNodeII
    {
        public Node Connect(Node root)
        {
            // Level by level.
            Node parent = root;
            while (parent != null)
            {
                Node dummyHead = new Node();
                Node child = dummyHead;
                while (parent != null) // Connect the current level.
                {
                    if (parent.left != null)
                    {
                        child.next = parent.left;
                        child = child.next;
                    }
                    if (parent.right != null)
                    {
                        child.next = parent.right;
                        child = child.next;
                    }
                    parent = parent.next;
                }
                parent = dummyHead.next;
            }
            return root;
        }

        public class Node
        {
            public int val;
            public Node left;
            public Node right;
            public Node next;

            public Node() { }
            public Node(int _val, Node _left, Node _right, Node _next)
            {
                val = _val;
                left = _left;
                right = _right;
                next = _next;
            }
        }
    }
}
