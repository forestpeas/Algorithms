using Algorithms.DataStructures;

namespace Algorithms.LeetCode
{
    /* 1367. Linked List in Binary Tree
     * 
     * Given a binary tree root and a linked list with head as the first node. 
     * 
     * Return True if all the elements in the linked list starting from the head correspond to some downward path
     * connected in the binary tree otherwise return False.
     * 
     * In this context downward path means a path that starts at some node and goes downwards.
     * 
     * Example 1:
     * https://leetcode.com/problems/linked-list-in-binary-tree/
     * Input: head = [4,2,8], root = [1,4,4,null,2,2,null,1,null,6,8,null,null,null,null,1,3]
     * Output: true
     * Explanation: Nodes in blue form a subpath in the binary Tree.  
     * 
     * Example 2:
     * 
     * Input: head = [1,4,2,6], root = [1,4,4,null,2,2,null,1,null,6,8,null,null,null,null,1,3]
     * Output: true
     * 
     * Example 3:
     * 
     * Input: head = [1,4,2,6,8], root = [1,4,4,null,2,2,null,1,null,6,8,null,null,null,null,1,3]
     * Output: false
     * Explanation: There is no path in the binary tree that contains all the elements of the linked list from head.
=
     */
    public class Linked_List_in_Binary_Tree
    {
        public bool IsSubPath(ListNode head, TreeNode root)
        {
            // Brute-force DFS.
            return Dfs(root, head);

            bool Dfs(TreeNode treeNode, ListNode listNode)
            {
                if (listNode == null) return true;
                if (treeNode == null) return false;
                if (treeNode.val == listNode.val)
                {
                    if (Dfs(treeNode.left, listNode.next)) return true;
                    if (Dfs(treeNode.right, listNode.next)) return true;
                }

                if (listNode == head)
                {
                    if (Dfs(treeNode.left, listNode)) return true;
                    if (Dfs(treeNode.right, listNode)) return true;
                }
                return false;
            }
        }
    }
}
