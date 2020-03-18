namespace Algorithms.LeetCode
{
    /* 1361. Validate Binary Tree Nodes
     * 
     * You have n binary tree nodes numbered from 0 to n - 1 where node i has two children
     * leftChild[i] and rightChild[i], return true if and only if all the given nodes form
     * exactly one valid binary tree.
     * 
     * If node i has no left child then leftChild[i] will equal -1, similarly for the right child.
     * 
     * Note that the nodes have no values and that we only use the node numbers in this problem.
     * 
     *  https://leetcode.com/problems/validate-binary-tree-nodes/
     */
    public class Validate_Binary_Tree_Nodes
    {
        public bool ValidateBinaryTreeNodes(int n, int[] leftChild, int[] rightChild)
        {
            // Think of all the "false cases".
            int[] indegrees = new int[n];
            int root = -1;
            for (int i = 0; i < n; i++)
            {
                if (leftChild[i] != -1) indegrees[leftChild[i]]++;
                if (rightChild[i] != -1) indegrees[rightChild[i]]++;
            }

            for (int i = 0; i < n; i++)
            {
                if (indegrees[i] == 0)
                {
                    if (root == -1) root = i;
                    else return false; // We have multiple roots.
                }
                else if (indegrees[i] != 1) return false;
            }

            if (root == -1) return false; // No root.

            return Dfs(root) == n; // For example: 1, 2 -> 3 -> 2

            int Dfs(int node)
            {
                if (node == -1) return 0;
                return 1 + Dfs(leftChild[node]) + Dfs(rightChild[node]);
            }
        }
    }
}
