using Algorithms.DataStructures;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 109. Convert Sorted List to Binary Search Tree
     * 
     * Given a singly linked list where elements are sorted in ascending order, convert it to a height balanced BST.
     * For this problem, a height-balanced binary tree is defined as a binary tree in which the depth of the two
     * subtrees of every node never differ by more than 1.
     * 
     * Example:
     * 
     * Given the sorted linked list: [-10,-3,0,5,9],
     * 
     * One possible answer is: [0,-3,9,-10,null,5], which represents the following height balanced BST:
     * 
     *       0
     *      / \
     *    -3   9
     *    /   /
     *  -10  5
     */
    public class ConvertSortedListToBinarySearchTree
    {
        public TreeNode SortedListToBST(ListNode head)
        {
            // Convert linked list to array
            var list = new List<int>();
            for (var node = head; node != null; node = node.next)
            {
                list.Add(node.val);
            }
            return new ConvertSortedArrayToBinarySearchTree().SortedArrayToBST(list.ToArray());
        }

        // A solution without the extra O(n) space of an array, inspired by "Approach 3: Inorder Simulation" from https://leetcode.com/articles/convert-sorted-list-to-binary-search-tree/.
        // Basically it's very similar to the recursive solution of "Problem 108. Convert Sorted Array to Binary Search Tree".
        // The only difference is we can't get the middle element immediately like in the array solution. Remember the inorder
        // traversal of a BST is in ascending order, so we let "head" be the pointer to simulate the traversal of the BST.
        // Before getting the middle element, we first traverse the left subtree, after that "head" must point to the middle
        // element we want(Because all the smaller elements have been traversed to form the left subtree).
        public TreeNode SortedListToBstInorderSimulation(ListNode head)
        {
            int length = 0;
            for (var node = head; node != null; node = node.next)
            {
                length++;
            }
            return SortedListToBST(0, length - 1);

            TreeNode SortedListToBST(int start, int end)
            {
                if (start > end) return null;
                int mid = (start + end) / 2;
                TreeNode left = SortedListToBST(start, mid - 1);
                TreeNode node = new TreeNode(head.val);
                node.left = left;
                head = head.next;
                node.right = SortedListToBST(mid + 1, end);
                return node;
            }
        }
    }
}
