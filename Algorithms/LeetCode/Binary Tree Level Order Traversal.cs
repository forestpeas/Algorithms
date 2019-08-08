using Algorithms.DataStructures;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 102. Binary Tree Level Order Traversal
     * 
     * Given a binary tree, return the level order traversal of its nodes' values. (ie, from left to right, level by level).
     * 
     * For example:
     * Given binary tree [3,9,20,null,null,15,7],
     *     3
     *    / \
     *   9  20
     *     /  \
     *    15   7
     * return its level order traversal as:
     * [
     *   [3],
     *   [9,20],
     *   [15,7]
     * ]
     */
    public class BinaryTreeLevelOrderTraversal
    {
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            // Straightforward BFS Solution
            if (root == null) return new int[0][];
            var result = new List<IList<int>>();
            var level = new List<TreeNode>() { root };
            while (level.Count != 0)
            {
                result.Add(level.Select(n => n.val).ToArray());
                var newLevel = new List<TreeNode>();
                foreach (var node in level)
                {
                    if (node.left != null) newLevel.Add(node.left);
                    if (node.right != null) newLevel.Add(node.right);
                }
                level = newLevel;
            }
            return result;
        }
    }
}
