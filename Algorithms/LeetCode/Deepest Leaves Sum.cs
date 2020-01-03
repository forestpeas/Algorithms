using Algorithms.DataStructures;

namespace Algorithms.LeetCode
{
    /* 1302. Deepest Leaves Sum
     * 
     * Given a binary tree, return the sum of values of its deepest leaves.
     * 
     * Example 1:
     * 
     * https://leetcode.com/problems/deepest-leaves-sum/
     * Input: root = [1,2,3,4,5,null,6,7,null,null,null,null,8]
     * Output: 15
     *  
     * Constraints:
     * The number of nodes in the tree is between 1 and 10^4.
     * The value of nodes is between 1 and 100.
     */
    public class Deepest_Leaves_Sum
    {
        public int DeepestLeavesSum(TreeNode root)
        {
            // BFS is also fine.
            int maxDepth = 0;
            int result = 0;
            Dfs(root, 0);
            return result;

            void Dfs(TreeNode node, int depth)
            {
                if (node.left == null && node.right == null)
                {
                    if (depth == maxDepth)
                    {
                        result += node.val;
                    }
                    else if (depth > maxDepth)
                    {
                        result = node.val;
                        maxDepth = depth;
                    }
                    return;
                }

                if (node.left != null) Dfs(node.left, depth + 1);
                if (node.right != null) Dfs(node.right, depth + 1);
            }
        }
    }
}
