using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 1377. Frog Position After T Seconds
     * 
     * Given an undirected tree consisting of n vertices numbered from 1 to n. A frog starts jumping
     * from the vertex 1. In one second, the frog jumps from its current vertex to another unvisited
     * vertex if they are directly connected. The frog can not jump back to a visited vertex. In case
     * the frog can jump to several vertices it jumps randomly to one of them with the same probability,
     * otherwise, when the frog can not jump to any unvisited vertex it jumps forever on the same vertex. 
     * 
     * The edges of the undirected tree are given in the array edges, where edges[i] = [fromi, toi]
     * means that exists an edge connecting directly the vertices fromi and toi.
     * 
     * Return the probability that after t seconds the frog is on the vertex target. 
     * 
     * Example 1:
     * https://leetcode.com/problems/frog-position-after-t-seconds/
     * Input: n = 7, edges = [[1,2],[1,3],[1,7],[2,4],[2,6],[3,5]], t = 2, target = 4
     * Output: 0.16666666666666666 
     * Explanation: The figure above shows the given graph. The frog starts at vertex 1, jumping with
     * 1/3 probability to the vertex 2 after second 1 and then jumping with 1/2 probability to vertex 4
     * after second 2. Thus the probability for the frog is on the vertex 4 after 2 seconds is 
     * 1/3 * 1/2 = 1/6 = 0.16666666666666666. 
     * 
     * Example 2:
     * 
     * Input: n = 7, edges = [[1,2],[1,3],[1,7],[2,4],[2,6],[3,5]], t = 1, target = 7
     * Output: 0.3333333333333333
     * Explanation: The figure above shows the given graph. The frog starts at vertex 1, jumping with
     * 1/3 = 0.3333333333333333 probability to the vertex 7 after second 1. 
     * 
     * Example 3:
     * 
     * Input: n = 7, edges = [[1,2],[1,3],[1,7],[2,4],[2,6],[3,5]], t = 20, target = 6
     * Output: 0.16666666666666666
     */
    public class Frog_Position_After_T_Seconds
    {
        public double FrogPosition(int n, int[][] edges, int t, int target)
        {
            var tree = new List<int>[n + 1];
            for (int i = 1; i <= n; i++)
            {
                tree[i] = new List<int>();
            }

            foreach (var e in edges)
            {
                // Assume parent node is always larger than child node.
                // Otherwise, we will have to construct a graph and maintain a "visited array".
                int parent = Math.Min(e[0], e[1]);
                int child = Math.Max(e[0], e[1]);
                tree[parent].Add(child);
            }

            double result = 0;
            int resultTime = 0;
            Dfs(1, 1.0, 0);
            if (t == resultTime) return result;
            if (t > resultTime && tree[target].Count == 0) return result; // forever on the "leaf".
            return 0.0;

            bool Dfs(int i, double p, int time)
            {
                if (i == target)
                {
                    result = p;
                    resultTime = time;
                    return true;
                }

                if (tree[i].Count == 0) return false;

                p = p * (1.0 / tree[i].Count);
                foreach (int child in tree[i])
                {
                    if (Dfs(child, p, time + 1)) return true;
                }

                return false;
            }
        }
    }
}
