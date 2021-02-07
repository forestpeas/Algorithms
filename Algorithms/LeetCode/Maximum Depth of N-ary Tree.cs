using Algorithms.DataStructures;
using System;

namespace Algorithms.LeetCode
{
    /* 559. Maximum Depth of N-ary Tree
     * 
     * Given a n-ary tree, find its maximum depth.
     * 
     * The maximum depth is the number of nodes along the longest path from
     * the root node down to the farthest leaf node.
     */
    public class Maximum_Depth_of_N_ary_Tree
    {
        public int MaxDepth(Node root)
        {
            if (root == null) return 0;
            int height = 0;
            foreach (var child in root.children)
            {
                height = Math.Max(height, MaxDepth(child));
            }
            return height + 1;
        }
    }
}
