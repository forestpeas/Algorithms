using Algorithms.DataStructures;

namespace Algorithms.LeetCode
{
    /* 1315. Sum of Nodes with Even-Valued Grandparent
     * 
     * Given a binary tree, return the sum of values of nodes with even-valued grandparent.
     * (A grandparent of a node is the parent of its parent, if it exists.)
     * 
     * If there are no nodes with an even-valued grandparent, return 0.
     * 
     * Example 1:
     * 
     * Input: root = [6,7,8,2,7,1,3,9,null,1,4,null,null,null,5]
     * Output: 18
     * Explanation: The red nodes are the nodes with even-value grandparent while the blue
     * nodes are the even-value grandparents.
     */
    public class Sum_of_Nodes_with_Even_Valued_Grandparent
    {
        public int SumEvenGrandparent(TreeNode root)
        {
            // DFS.
            if (root == null) return 0;
            int sum = 0;
            if (root.val % 2 == 0)
            {
                if (root.left != null)
                {
                    if (root.left.left != null) sum += root.left.left.val;
                    if (root.left.right != null) sum += root.left.right.val;
                }
                if (root.right != null)
                {
                    if (root.right.left != null) sum += root.right.left.val;
                    if (root.right.right != null) sum += root.right.right.val;
                }
            }

            sum += SumEvenGrandparent(root.left);
            sum += SumEvenGrandparent(root.right);
            return sum;
        }
    }
}
