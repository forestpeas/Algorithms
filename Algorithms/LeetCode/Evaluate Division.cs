using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 399. Evaluate Division
     * 
     * Equations are given in the format A / B = k, where A and B are variables represented as strings, and k is
     * a real number (floating point number). Given some queries, return the answers. If the answer does not exist,
     * return -1.0.
     * 
     * Example:
     * Given a / b = 2.0, b / c = 3.0.
     * queries are: a / c = ?, b / a = ?, a / e = ?, a / a = ?, x / x = ? .
     * return [6.0, 0.5, -1.0, 1.0, -1.0 ].
     * 
     * The input is always valid. You may assume that evaluating the queries will result in no division by zero and
     * there is no contradiction.
     */
    public class EvaluateDivision
    {
        // Because floating point numbers may lose accuracy, e.g. 2.0 / 1.0 may not be equal to (2.0 * 2) / (1.0 * 2),
        // we have to use the origin values to calculate the result to guarantee the maximum accuracy we can achieve.
        // The problem becomes a graph problem. For example, a / b = 2.0, a and b are vertex, 2.0 is the weight of
        // the edge from a to b, and 1 / 2.0 is the weight of the edge from b to a. Given 2 vertex, we need to find
        // a path between them, and multiplying all the path weights gives us the result value.
        private class Neighbor
        {
            public readonly string vertice;
            public readonly double edge;
            public Neighbor(string v, double e)
            {
                vertice = v;
                edge = e;
            }
        }

        public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
        {
            // Key is a vertice, value is its neighbors.
            var map = new Dictionary<string, List<Neighbor>>();

            for (int i = 0; i < values.Length; i++)
            {
                if (!map.TryGetValue(equations[i][0], out var neighbors))
                {
                    neighbors = new List<Neighbor>();
                    map.Add(equations[i][0], neighbors);
                }
                neighbors.Add(new Neighbor(equations[i][1], values[i]));

                if (!map.TryGetValue(equations[i][1], out neighbors))
                {
                    neighbors = new List<Neighbor>();
                    map.Add(equations[i][1], neighbors);
                }
                neighbors.Add(new Neighbor(equations[i][0], 1 / values[i]));
            }

            double[] result = new double[queries.Count];
            for (int i = 0; i < queries.Count; i++)
            {
                result[i] = Dfs(queries[i][0], queries[i][1], 1, new HashSet<string>());
            }

            return result;

            double Dfs(string start, string end, double currVal, HashSet<string> seen)
            {
                if (!map.ContainsKey(start) || !seen.Add(start)) return -1;
                if (start == end) return currVal;

                foreach (var neighbor in map[start])
                {
                    double finalVal = Dfs(neighbor.vertice, end, currVal * neighbor.edge, seen);
                    if (finalVal != -1) return finalVal;
                }

                return -1;
            }
        }
    }
}
