using Algorithms.DataStructures;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 652. Find Duplicate Subtrees
     * 
     * Given the root of a binary tree, return all duplicate subtrees.
     * For each kind of duplicate subtrees, you only need to return the root node of any one of them. 
     * Two trees are duplicate if they have the same structure with the same node values.
     * 
     * https://leetcode.com/problems/find-duplicate-subtrees/
     */
    public class Find_Duplicate_Subtrees
    {
        public IList<TreeNode> FindDuplicateSubtrees(TreeNode root)
        {
            var seen = new Dictionary<string, int>();
            var res = new List<TreeNode>();
            Dfs(root);
            return res;

            string Dfs(TreeNode node)
            {
                if (node == null) return "#";
                string key = node.val.ToString() + "," + Dfs(node.left) + "," + Dfs(node.right);
                seen[key] = seen.GetValueOrDefault(key) + 1;
                if (seen[key] == 2)
                {
                    res.Add(node);
                }
                return key;
            }
        }
    }
}
