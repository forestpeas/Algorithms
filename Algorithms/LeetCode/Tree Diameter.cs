using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 1245. Tree Diameter
     * 
     * Given an undirected tree, return its diameter: the number of edges in a longest path in that tree.
     * 
     * The tree is given as an array of edges where edges[i] = [u, v] is a bidirectional edge between nodes
     * u and v.  Each node has labels in the set {0, 1, ..., edges.length}.
     * 
     * https://leetcode.com/problems/tree-diameter/
     */
    public class Tree_Diameter
    {
        public int TreeDiameter(int[][] edges)
        {
            // Similar to "310. Minimum Height Trees".
            // DFS: Start at any node A and traverse the tree to find the furthest node from it, let's call it B.
            // Having found the furthest node B, traverse the tree from B to find the furthest node from it, let's
            // call it C. The distance between B and C is the tree diameter.
            // BFS: The solution below.
            if (edges.Length == 0) return 0;
            var graph = new HashSet<int>[edges.Length + 1];
            for (int i = 0; i < graph.Length; i++) graph[i] = new HashSet<int>();
            foreach (var e in edges)
            {
                graph[e[0]].Add(e[1]);
                graph[e[1]].Add(e[0]);
            }

            var delete = new List<int>();
            for (int i = 0; i < graph.Length; i++)
            {
                if (graph[i].Count == 1) delete.Add(i);
            }

            int n = graph.Length;
            int count = 0;
            while (n > 2)
            {
                var newDelete = new List<int>();
                foreach (int v in delete)
                {
                    int neighbor = graph[v].Single();
                    graph[neighbor].Remove(v);
                    if (graph[neighbor].Count == 1) newDelete.Add(neighbor);
                }

                n -= delete.Count;
                delete = newDelete;
                count++;
            }

            if (n == 1) return count * 2;
            return count * 2 + 1;
        }
    }
}
