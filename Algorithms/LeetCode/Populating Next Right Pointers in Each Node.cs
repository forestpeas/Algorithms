namespace Algorithms.LeetCode
{
    /* 116. Populating Next Right Pointers in Each Node
     * 
     * You are given a perfect binary tree where all leaves are on the same level,
     * and every parent has two children. The binary tree has the following definition:
     * 
     * struct Node {
     *   int val;
     *   Node *left;
     *   Node *right;
     *   Node *next;
     * }
     * 
     * Populate each next pointer to point to its next right node. If there is no next
     * right node, the next pointer should be set to NULL.
     * 
     * Initially, all next pointers are set to NULL.
     * 
     * For illustration and more clarifications: https://leetcode.com/problems/populating-next-right-pointers-in-each-node/.
     */
    public class PopulatingNextRightPointersInEachNode
    {
        public Node Connect(Node root)
        {
            if (root == null) return null;
            Connect(root.left);
            Connect(root.right);

            // For example, when root is the top node in the following tree,
            // set next pointers, shown as the arrows below.
            //           1
            //          / \
            // 	    1    →    1
            //     / \       / \
            //    1   1  →  1   1
            //   /\   /\    /\  /\
            //  1  1 1  1→ 1 1 1  1
            Node left = root.left;
            Node right = root.right;
            while (left != null)
            {
                left.next = right;
                left = left.right;
                right = right.left;
            }
            return root;
        }

        public Node ConnectIterative(Node root)
        {
            // Iterative solution, similar to the solution above.
            // Top down, with constant space.
            Node node = root;
            Node leftMost = node; // Leftmost node in current level.
            while (node != null)
            {
                Node left = node.left;
                Node right = node.right;
                while (left != null)
                {
                    left.next = right;
                    left = left.right;
                    right = right.left;
                }

                node = node.next;
                if (node == null) // Level by level.
                {
                    node = leftMost.left;
                    leftMost = node;
                }
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
