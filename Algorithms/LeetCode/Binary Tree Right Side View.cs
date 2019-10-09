using Algorithms.DataStructures;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 199. Binary Tree Right Side View
     * 
     * Given a binary tree, imagine yourself standing on the right side of it,
     * return the values of the nodes you can see ordered from top to bottom.
     * 
     * Example:
     * 
     * Input: [1,2,3,null,5,null,4]
     * Output: [1, 3, 4]
     * Explanation:
     * 
     *    1            <---
     *  /   \
     * 2     3         <---
     *  \     \
     *   5     4       <---
     *   
     * Example 2:
     * 
     * Input: [1,2,3,4]
     * Output: [1, 3, 4]
     * Explanation:
     * 
     *      1          <---
     *    /   \
     *   2     3       <---
     *  /
     * 4               <---
     */
    public class BinaryTreeRightSideView
    {
        public IList<int> RightSideView(TreeNode root)
        {
            // DFS. Always traverse the right subtree first. Save the maximum depth
            // we have been to. When coming back from a right subtree, traverse the
            // left subtree but only when the depth is deeper than the maximum depth
            // do we add the node to result.
            var result = new List<int>();
            int maxDepth = 0;
            RightSideView(root, 0);
            return result;

            void RightSideView(TreeNode node, int depth)
            {
                if (node == null) return;
                if (++depth > maxDepth)
                {
                    maxDepth = depth;
                    result.Add(node.val);
                }

                RightSideView(node.right, depth);
                RightSideView(node.left, depth);
            }
        }

        public IList<int> RightSideViewBFS(TreeNode root)
        {
            // BFS. Traverse the tree level by level, add last node of every level to result.
            if (root == null) return new int[0];
            var result = new List<int>();
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                int size = queue.Count;
                while (true)
                {
                    TreeNode node = queue.Dequeue();
                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                    if (--size == 0) // node is the last one of the current level.
                    {
                        result.Add(node.val);
                        break;
                    }
                }
            }

            return result;
        }
    }
}
