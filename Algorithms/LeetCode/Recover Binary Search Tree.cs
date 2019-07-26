using Algorithms.DataStructures;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 99. Recover Binary Search Tree
     * 
     * Two elements of a binary search tree (BST) are swapped by mistake.
     * Recover the tree without changing its structure.
     * 
     * Example 1:
     * 
     * Input: [1,3,null,null,2]
     * 
     *    1
     *   /
     *  3
     *   \
     *    2
     * 
     * Output: [3,1,null,null,2]
     * 
     *    3
     *   /
     *  1
     *   \
     *    2
     * 
     * Example 2:
     * 
     * Input: [3,1,4,null,null,2]
     * 
     *   3
     *  / \
     * 1   4
     *    /
     *   2
     * 
     * Output: [2,1,4,null,null,3]
     * 
     *   2
     *  / \
     * 1   4
     *    /
     *   3
     * 
     * Follow up:
     * 
     * A solution using O(n) space is pretty straight forward.
     * Could you devise a constant space solution?
     */
    public class RecoverBinarySearchTree
    {
        public void RecoverTree(TreeNode root)
        {
            // The problem can be simplified to "Find two swapped number in a sorted array" 
            // because inorder traversal of a BST is the same to iterating through a sorted array.
            // There are two cases: for example, let the sorted array be 
            // [1,2,3,4,5,6,7,8]
            // If we swap 2 with 6, we get:
            // [1,6,3,4,5,2,7,8]
            // First we find a number that is less than its previous element, i.e. 6 and 3.
            // Then we find a second number that is less than its previous element, i.e. 5 and 2.
            // Swap 6 with 2.
            // if we swap 2 with 3, we get:
            // [1,3,2,4,5,6,7,8]
            // First we find a number that is less than its previous element, i.e. 3 and 2.
            // We cannot find a second number that is less than its previous element.
            // Simply swap 3 with 2.
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode node = root;
            TreeNode mistakenNode = null;
            TreeNode mistakenNodeNext = null;
            TreeNode last = null;
            while (stack.Count != 0 || node != null)
            {
                while (node != null)
                {
                    stack.Push(node);
                    node = node.left;
                }

                node = stack.Pop();

                if (last != null && node.val <= last.val)
                {
                    if (mistakenNode != null)
                    {
                        // Swap the current node with the first mistaken node.
                        Swap(node, mistakenNode);
                        return;
                    }
                    mistakenNode = last;
                    mistakenNodeNext = node;
                }
                last = node;
                node = node.right;
            }
            Swap(mistakenNode, mistakenNodeNext);
        }

        private void Swap(TreeNode first, TreeNode second)
        {
            int tmp = first.val;
            first.val = second.val;
            second.val = tmp;
        }
    }
}
