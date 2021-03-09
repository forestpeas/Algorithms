using Algorithms.DataStructures;
using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 1786. Number of Restricted Paths From First to Last Node
     * 
     * https://leetcode.com/problems/number-of-restricted-paths-from-first-to-last-node/
     */
    public class Number_of_Restricted_Paths_From_First_to_Last_Node
    {
        public int CountRestrictedPaths(int n, int[][] edges)
        {
            var graph = new Graph(n, edges);
            int[] dist = new int[n + 1];
            Array.Fill(dist, int.MaxValue);
            dist[n] = 0;
            var pq = new PriorityQueue<Item>(Comparer<Item>.Create((x, y) => y.dist - x.dist));
            pq.Add(new Item { dist = 0, v = n });
            var spt = new HashSet<int>(); // shortest-paths tree
            while (pq.Count != 0)
            {
                var v = pq.DeleteTop().v;
                if (!spt.Add(v)) continue;
                foreach (var w in graph.AdjacentsOf(v))
                {
                    if (dist[w.other] > dist[v] + w.weight)
                    {
                        dist[w.other] = dist[v] + w.weight;
                        pq.Add(new Item { v = w.other, dist = dist[w.other] });
                    }
                }
            }

            int?[] mem = new int?[n + 1];
            return Dfs(1);

            int Dfs(int v)
            {
                if (v == n) return 1;
                if (mem[v].HasValue) return mem[v].Value;
                int res = 0;
                foreach (var edge in graph.AdjacentsOf(v))
                {
                    if (dist[edge.other] < dist[v])
                    {
                        res += Dfs(edge.other);
                        res %= 1000000007;
                    }
                }
                mem[v] = res;
                return res;
            }
        }

        private class Graph
        {
            private readonly List<Edge>[] _adjacents;

            public Graph(int n, int[][] edges)
            {
                _adjacents = new List<Edge>[n + 1];
                for (int i = 0; i < n + 1; i++)
                {
                    _adjacents[i] = new List<Edge>();
                }
                foreach (var edge in edges)
                {
                    _adjacents[edge[0]].Add(new Edge { other = edge[1], weight = edge[2] });
                    _adjacents[edge[1]].Add(new Edge { other = edge[0], weight = edge[2] });
                }
            }

            public IEnumerable<Edge> AdjacentsOf(int v) => _adjacents[v];
        }

        private class Edge
        {
            public int other;
            public int weight;
        }

        private class Item
        {
            public int dist;
            public int v;
        }
    }
}
