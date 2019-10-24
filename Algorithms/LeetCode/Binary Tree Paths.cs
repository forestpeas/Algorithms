using Algorithms.DataStructures;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 257. Binary Tree Paths
     * 
     * Given a binary tree, return all root-to-leaf paths.
     * 
     * Note: A leaf is a node with no children.
     * 
     * Example:
     * 
     * Input:
     * 
     *    1
     *  /   \
     * 2     3
     *  \
     *   5
     * 
     * Output: ["1->2->5", "1->3"]
     * 
     * Explanation: All root-to-leaf paths are: 1->2->5, 1->3
     */
    public class BinaryTreePathsSolution
    {
        public IList<string> BinaryTreePaths(TreeNode root)
        {
            var result = new List<string>();
            if (root != null) BinaryTreePaths(root, string.Empty);
            return result;

            void BinaryTreePaths(TreeNode node, string path)
            {
                if (node.left == null && node.right == null)
                {
                    result.Add(path + node.val);
                    return;
                }

                path = path + node.val + "->";
                if (node.left != null) BinaryTreePaths(node.left, path);
                if (node.right != null) BinaryTreePaths(node.right, path);
            }
        }
    }
}
