using Algorithms.DataStructures;

namespace Algorithms.LeetCode
{
    /* 222. Count Complete Tree Nodes
     * 
     * Given a complete binary tree, count the number of nodes.
     * 
     * Note:
     * 
     * Definition of a complete binary tree from Wikipedia:
     * In a complete binary tree every level, except possibly the last, is completely filled,
     * and all nodes in the last level are as far left as possible. It can have between 1 and
     * 2^h nodes inclusive at the last level h.
     * 
     * Example:
     * 
     * Input: 
     *     1
     *    / \
     *   2   3
     *  / \  /
     * 4  5 6
     * 
     * Output: 6
     */
    public class CountCompleteTreeNodes
    {
        public int CountNodes(TreeNode root)
        {
            // Convise solution inspired by https://leetcode.com/problems/count-complete-tree-nodes/discuss/61958/Concise-Java-solutions-O(log(n)2)
            // If h = height of the tree(h is zero-based), and the left subtree is a full tree of height h-1,
            // the number of root node and the left subtree is 1 + (2^h-1) = 2^h = 1 << h
            // The same goes for the right subtree.
            int h = GetHeight(root);
            return h < 0 ? 0 :
                   GetHeight(root.right) == h - 1 ? (1 << h) + CountNodes(root.right) // left subtree is a full tree of height h-1.
                                             : (1 << h - 1) + CountNodes(root.left); // right subtree is a full tree of height h-2.
        }

        private int GetHeight(TreeNode root)
        {
            return root == null ? -1 : 1 + GetHeight(root.left);
        }

        public int CountNodes2(TreeNode root)
        {
            // My first attempt on this problem.
            if (root == null) return 0;

            int maxLevel = 0;
            int maxLevelNodes = 1;
            int totalNodes = 1;
            TreeNode node = root.left;
            while (node != null)
            {
                maxLevel++;
                maxLevelNodes *= 2;
                totalNodes += maxLevelNodes;
                node = node.left;
            }

            // Think of the last row in the tree as an array starting from index 0.
            // Find the index of the first null element in the array, which is also
            // the number of nodes in the last row.
            int lo = 0;
            int hi = maxLevelNodes;
            while (lo < hi) // Search range [0, 2^h)
            {
                // "mid" corresponds to the leftmost node in root.right.
                // When "lo" and "hi" converge to the same value, "node" will be the first
                // null node in the last row.
                node = maxLevel > 0 ? root.right : root;
                int levels = maxLevel - 1;
                while (levels > 0)
                {
                    levels--;
                    node = node.left;
                }

                int mid = lo + (hi - lo) / 2;
                if (node == null)
                {
                    hi = mid;
                    root = root.left;
                }
                else
                {
                    lo = mid + 1;
                    root = root.right;
                }

                maxLevel--;
            }

            return totalNodes - maxLevelNodes + lo;
        }
    }
}
