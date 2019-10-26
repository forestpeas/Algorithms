using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 310. Minimum Height Trees
     * 
     * For an undirected graph with tree characteristics, we can choose any node as the root. The result
     * graph is then a rooted tree. Among all possible rooted trees, those with minimum height are called
     * minimum height trees (MHTs). Given such a graph, write a function to find all the MHTs and return
     * a list of their root labels.
     * 
     * Format
     * The graph contains n nodes which are labeled from 0 to n - 1. You will be given the number n and a
     * list of undirected edges (each edge is a pair of labels).
     * 
     * You can assume that no duplicate edges will appear in edges. Since all edges are undirected, [0, 1]
     * is the same as [1, 0] and thus will not appear together in edges.
     * 
     * Example 1 :
     * 
     * Input: n = 4, edges = [[1, 0], [1, 2], [1, 3]]
     * 
     *         0
     *         |
     *         1
     *        / \
     *       2   3 
     * 
     * Output: [1]
     * 
     * Example 2 :
     * 
     * Input: n = 6, edges = [[0, 3], [1, 3], [2, 3], [4, 3], [5, 4]]
     * 
     *      0  1  2
     *       \ | /
     *         3
     *         |
     *         4
     *         |
     *         5 
     * 
     * Output: [3, 4]
     * 
     * Note:
     * 
     *     According to the definition of tree on Wikipedia: “a tree is an undirected graph in which any
     *     two vertices are connected by exactly one path. In other words, any connected graph without
     *     simple cycles is a tree.”
     *     
     *     The height of a rooted tree is the number of edges on the longest downward path between the root
     *     and a leaf.
     */
    public class MinimumHeightTrees
    {
        public IList<int> FindMinHeightTrees(int n, int[][] edges)
        {
            // Inspired by https://leetcode.com/problems/minimum-height-trees/discuss/76055/Share-some-thoughts
            // A minimum height tree's root must be the longest path's middle node. In every round, we remove
            // the leaves (vertices with only 1 neighbor), until there are only 1 or 2 vertices.
            if (n == 1) return new int[1];

            var graph = new HashSet<int>[n];
            for (int i = 0; i < n; i++) graph[i] = new HashSet<int>();
            foreach (var e in edges)
            {
                graph[e[0]].Add(e[1]);
                graph[e[1]].Add(e[0]);
            }

            var leaves = new List<int>();
            for (int i = 0; i < n; i++)
            {
                if (graph[i].Count == 1) leaves.Add(i);
            }

            while (n > 2)
            {
                n -= leaves.Count;
                var newLeaves = new List<int>();
                foreach (int l in leaves)
                {
                    int neighbor = graph[l].Single();
                    graph[neighbor].Remove(l);
                    if (graph[neighbor].Count == 1) newLeaves.Add(neighbor);
                }

                leaves = newLeaves;
            }

            return leaves;
        }
    }
}
