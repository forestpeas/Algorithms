using Algorithms.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 662. Maximum Width of Binary Tree
     * 
     * Given a binary tree, write a function to get the maximum width of the given tree. The maximum width
     * of a tree is the maximum width among all levels.
     * 
     * The width of one level is defined as the length between the end-nodes (the leftmost and right most
     * non-null nodes in the level, where the null nodes between the end-nodes are also counted into the
     * length calculation.
     * 
     * It is guaranteed that the answer will in the range of 32-bit signed integer.
     * 
     * Example 1:
     * 
     * Input: 
     * 
     *            1
     *          /   \
     *         3     2
     *        / \     \  
     *       5   3     9 
     * 
     * Output: 4
     * Explanation: The maximum width existing in the third level with the length 4 (5,3,null,9).
     * 
     * Example 2:
     * 
     * Input: 
     * 
     *           1
     *          /  
     *         3    
     *        / \       
     *       5   3     
     * 
     * Output: 2
     * Explanation: The maximum width existing in the third level with the length 2 (5,3).
     * 
     * Example 3:
     * 
     * Input: 
     * 
     *           1
     *          / \
     *         3   2 
     *        /        
     *       5      
     * 
     * Output: 2
     * Explanation: The maximum width existing in the second level with the length 2 (3,2).
     * 
     * Example 4:
     * 
     * Input: 
     * 
     *           1
     *          / \
     *         3   2
     *        /     \  
     *       5       9 
     *      /         \
     *     6           7
     * Output: 8
     * Explanation:The maximum width existing in the fourth level with the length 8 (6,null,null,null,
     * null,null,null,7).
     */
    public class Maximum_Width_of_Binary_Tree
    {
        public int WidthOfBinaryTree(TreeNode root)
        {
            // treat TreeNode.val as its position on a level
            int res = 0;
            var queue = new Queue<TreeNode>();
            root.val = 0;
            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                res = Math.Max(res, queue.Last().val - queue.First().val + 1);
                for (int count = queue.Count; count > 0; count--)
                {
                    var node = queue.Dequeue();
                    if (node.left != null)
                    {
                        node.left.val = node.val * 2;
                        queue.Enqueue(node.left);
                    }
                    if (node.right != null)
                    {
                        node.right.val = node.val * 2 + 1;
                        queue.Enqueue(node.right);
                    }
                }
            }
            return res;
        }
    }
}
