using Algorithms.DataStructures;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 501. Find Mode in Binary Search Tree
     * 
     * Given a binary search tree (BST) with duplicates, find all the mode(s) (the most
     * frequently occurred element) in the given BST.
     * 
     * Assume a BST is defined as follows:
     * 
     * The left subtree of a node contains only nodes with keys less than or equal to
     * the node's key.
     * The right subtree of a node contains only nodes with keys greater than or equal
     * to the node's key.
     * Both the left and right subtrees must also be binary search trees. 
     * 
     * For example:
     * Given BST [1,null,2,2],
     * 
     *    1
     *     \
     *      2
     *     /
     *    2
     *  
     * 
     * return [2].
     * 
     * Note: If a tree has more than one mode, you can return them in any order.
     * 
     * Follow up: Could you do that without using any extra space? (Assume that the
     * implicit stack space incurred due to recursion does not count).
     */
    public class Find_Mode_in_Binary_Search_Tree
    {
        public int[] FindMode(TreeNode root)
        {
            int? prev = null;
            int count = 0, maxCount = 0;
            var res = new List<int>();
            Find(root);
            if (prev != null && count >= maxCount)
            {
                if (count > maxCount) res.Clear();
                res.Add(prev.Value);
            }
            return res.ToArray();

            void Find(TreeNode node)
            {
                if (node == null) return;
                Find(node.left);
                if (node.val == prev)
                {
                    count++;
                }
                else
                {
                    if (prev != null && count >= maxCount)
                    {
                        if (count > maxCount) res.Clear();
                        res.Add(prev.Value);
                        maxCount = count;
                    }
                    prev = node.val;
                    count = 1;
                }
                Find(node.right);
            }
        }
    }
}
