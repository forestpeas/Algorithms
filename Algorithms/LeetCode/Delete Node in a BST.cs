using Algorithms.DataStructures;

namespace Algorithms.LeetCode
{
    /* 450. Delete Node in a BST
     * 
     * Given a root node reference of a BST and a key, delete the node with the given key
     * in the BST. Return the root node reference (possibly updated) of the BST.
     * 
     * Basically, the deletion can be divided into two stages:
     * 
     * Search for a node to remove.
     * If the node is found, delete the node.
     * 
     * https://leetcode.com/problems/delete-node-in-a-bst/
     */
    public class Delete_Node_in_a_BST
    {
        public TreeNode DeleteNode(TreeNode root, int key)
        {
            if (root == null) return null;
            if (root.val > key)
            {
                root.left = DeleteNode(root.left, key);
            }
            else if (root.val < key)
            {
                root.right = DeleteNode(root.right, key);
            }
            else
            {
                if (root.left == null) return root.right;
                if (root.right == null) return root.left;
                var leftMaxChild = root.left;
                while (leftMaxChild.right != null) leftMaxChild = leftMaxChild.right;
                leftMaxChild.right = root.right;
                return root.left;
            }
            return root;
        }

        public class Solution2
        {
            public TreeNode DeleteNode(TreeNode root, int key)
            {
                if (root == null) return null;
                if (root.val == key)
                {
                    // Replace the current node with leftMaxChild or rightMinChild.
                    if (root.left != null)
                    {
                        var leftMaxChild = RemoveMax(root.left, root);
                        leftMaxChild.left = root.left;
                        leftMaxChild.right = root.right;
                        return leftMaxChild;
                    }
                    if (root.right != null)
                    {
                        var rightMinChild = RemoveMin(root.right, root);
                        rightMinChild.right = root.right;
                        rightMinChild.left = root.left;
                        return rightMinChild;
                    }
                    return null;
                }
                root.left = DeleteNode(root.left, key);
                root.right = DeleteNode(root.right, key);
                return root;
            }

            private TreeNode RemoveMax(TreeNode node, TreeNode parent)
            {
                if (node.right == null)
                {
                    if (parent.left == node) parent.left = node.left;
                    else parent.right = node.left;
                    return node;
                }
                return RemoveMax(node.right, node);
            }

            private TreeNode RemoveMin(TreeNode node, TreeNode parent)
            {
                if (node.left == null)
                {
                    if (parent.right == node) parent.right = node.right;
                    else parent.left = node.right;
                    return node;
                }
                return RemoveMin(node.left, node);
            }
        }
    }
}
