namespace Algorithms.LeetCode
{
    /* 1273. Delete Tree Nodes
     * 
     * A tree rooted at node 0 is given as follows:
     *     The number of nodes is nodes;
     *     The value of the i-th node is value[i];
     *     The parent of the i-th node is parent[i].
     * 
     * Remove every subtree whose sum of values of nodes is zero.
     * After doing so, return the number of nodes remaining in the tree.
     * 
     * Example 1:
     * Input: nodes = 7, parent = [-1,0,0,1,2,2,2], value = [1,-2,4,0,-2,-1,-1]
     * Output: 2
     * 
     * https://leetcode.com/problems/delete-tree-nodes/
     */
    public class Delete_Tree_Nodes
    {
        public int DeleteTreeNodes(int nodes, int[] parent, int[] value)
        {
            // Hidding condition:
            // parernt[i] < i for all i > 0        
            // From leaves to the root, check each subtree's sum.
            int[] children = new int[nodes]; // The number of children of the i-th node.
            for (int i = nodes - 1; i >= 0; i--)
            {
                if (value[i] == 0)
                {
                    nodes -= children[i] + 1;
                    continue;
                }

                if (i == 0) break;
                children[parent[i]] += children[i] + 1;
                value[parent[i]] += value[i];
            }

            return nodes;
        }
    }
}
