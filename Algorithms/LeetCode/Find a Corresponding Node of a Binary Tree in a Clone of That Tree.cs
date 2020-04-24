using Algorithms.DataStructures;

namespace Algorithms.LeetCode
{
    /* 1379. Find a Corresponding Node of a Binary Tree in a Clone of That Tree
     * 
     * Given two binary trees original and cloned and given a reference to a node target in the original tree.
     * 
     * The cloned tree is a copy of the original tree.
     * 
     * Return a reference to the same node in the cloned tree.
     * 
     * Note that you are not allowed to change any of the two trees or the target node and the answer must be
     * a reference to a node in the cloned tree.
     * 
     * Example 1:
     * https://leetcode.com/problems/find-a-corresponding-node-of-a-binary-tree-in-a-clone-of-that-tree/
     * Input: tree = [7,4,3,null,null,6,19], target = 3
     * Output: 3
     * Explanation: In all examples the original and cloned trees are shown. The target node is a green node
     * from the original tree. The answer is the yellow node from the cloned tree.
     * 
     * Example 2:
     * 
     * Input: tree = [7], target =  7
     * Output: 7
     */
    public class Find_a_Corresponding_Node_of_a_Binary_Tree_in_a_Clone_of_That_Tree
    {
        public TreeNode GetTargetCopy(TreeNode original, TreeNode cloned, TreeNode target)
        {
            TreeNode result = null;
            Dfs(original, cloned);
            return result;

            // Returns true if we find the target.
            bool Dfs(TreeNode o, TreeNode c)
            {
                if (o == null) return false;
                if (o == target)
                {
                    result = c;
                    return true;
                }

                if (Dfs(o.left, c.left)) return true;
                if (Dfs(o.right, c.right)) return true;
                return false;
            }
        }
    }
}
